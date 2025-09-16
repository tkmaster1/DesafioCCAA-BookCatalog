using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Entities;
using BookCatalog.Common.Util.Messages;
using BookCatalog.Common.Util.Response;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Facades.Interfaces;
using BookCatalog.Core.Service.Helper;
using BookCatalog.Core.Service.Settings;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BookCatalog.Core.Service.Facades;

/// <summary>
/// Serviço de autenticação para login e registro de usuários.
/// </summary>
public class AuthFacade : IAuthFacade
{
    #region Properties

    private readonly IMapper _mapper;
    private readonly IUserAppService _usersAppService;
    private readonly IUserClaimsAppService _userClaimsAppService;
    private readonly IEmailAppService _emailAppService;
    private readonly IConfiguration _config;

    #endregion

    #region Constructor

    public AuthFacade(IMapper mapper,
                      IUserAppService usersAppService,
                      IUserClaimsAppService userClaimsAppService,
                      IEmailAppService emailAppService,
                      IConfiguration config)
    {
        _mapper = mapper;
        _usersAppService = usersAppService;
        _userClaimsAppService = userClaimsAppService;
        _emailAppService = emailAppService;
        _config = config;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Realiza o login do usuário e verifica a senha.
    /// </summary>
    public async Task<LoginUserDTO> LoginAsync(LoginRequestDTO requestDTO)
    {
        var user = new User();

        user = await _usersAppService.GetByEmailAsync(requestDTO.Email);

        var isValid = user != null && VerifyPassword(requestDTO.PasswordHash, user.PasswordHash);

        return new LoginUserDTO
        {
            Succeeded = isValid,
            Message = isValid
                ? ValidationMessages.MSG_SUCCESSLOGINFUL
                : ValidationMessages.MSG_FAILED
        };
    }

    /// <summary>
    /// Realiza o cadstro do usuário no sistema
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<LoginUserDTO> RegisterUserAsync(RegisterRequestDTO requestDTO)
    {
        var exists = new User();
        bool isValid = false;

        exists = await _usersAppService.GetByEmailAsync(requestDTO.Email);

        if (exists != null)
            throw new InvalidOperationException("Já existe um usuário com este e-mail informados.");

        var user = GetUserFromRegisterUser(requestDTO);

        if (!string.IsNullOrEmpty(await _usersAppService.AddUserAsync(user)))
            isValid = true;

        return new LoginUserDTO
        {
            Succeeded = isValid,
            Message = isValid
                 ? ValidationMessages.MSG_SUCCESSREGISTERFUL
                 : ValidationMessages.MSG_FAILED
        };
    }

    /// <summary>
    /// Realiza a geração do token JWT.
    /// </summary>
    public async Task<LoginResponseDTO> GerarJwtAsync(string email, AuthorizationSettings authorizationSettings)
    {
        var user = new User();

        user = await _usersAppService.GetByEmailAsync(email);

        var roles = await _usersAppService.GetRolesAsync(user.CodeUser);

        var identityClaims = await ClaimsHelper.GetClaimsUser(user, roles);

        var encodedToken = TokenBuilder.GenerateToken(identityClaims, authorizationSettings);

        return GetResponseToken(encodedToken, user, identityClaims.Claims, authorizationSettings);
    }

    public async Task<ForgotPasswordResponse> ForgotPassword(string email)
    {
        var user = await _usersAppService.GetByEmailAsync(email);
        if (user == null)
            return null;

        // 🔹 Gerar token aleatório
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        // (Opcional) salvar token no banco em tabela PasswordResetToken
        // ou em cache (Redis) com expiração.

        var callbackUrl = $"{_config["Frontend:BaseUrl"]}/reset-password?email={user.Email}&token={token}";

        var body = $@"
            <h2>Recuperação de Senha</h2>
            <p>Olá {user.Name},</p>
            <p>Clique no link abaixo para redefinir sua senha:</p>
            <a href='{callbackUrl}'>Resetar Senha</a>
        ";

        var obj = new EmailModel()
        {
            UserName = user.Name,
            Recipient = user.Email,
            Subject =  "Redefinição de Senha",
            Body = body
        };

        await _emailAppService.SendEmailAsync(obj);

        return new ForgotPasswordResponse
        {
            CodeUser = user.CodeUser, // ou outro campo que represente CodeUser
            Email = user.Email,
            Token = token
        };
    }

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion

    #region Methods Private

    /// <summary>
    /// Monta a resposta de login contendo o token JWT, tempo de expiração e dados do usuário autenticado.
    /// </summary>
    /// <param name="encodedToken">Token JWT já gerado.</param>
    /// <param name="user">Entidade do usuário autenticado.</param>
    /// <param name="claims">Lista de claims associadas ao usuário.</param>
    /// <param name="authorizationSettings">Configurações de autenticação (expiração, etc).</param>
    /// <returns>Objeto de resposta estruturado para retorno no login.</returns>
    private LoginResponseDTO GetResponseToken(string encodedToken, User user, IEnumerable<Claim> claims, AuthorizationSettings authorizationSettings)
    {
        return new LoginResponseDTO
        {
            AccessToken = encodedToken,
            ExpiresAtUtc = DateTimeOffset.UtcNow.Add(
                TimeSpan.FromDays(authorizationSettings.ExpirationDays)
            ),
            UserToken = new UserTokenDTO
            {
                Id = user.CodeUser,
                Email = user.Email,
                UserName = user.Name,
                //  FileNameImage = userProfilePicture != null ? userProfilePicture.FileName : string.Empty,
                Claims = claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value }).ToList()
            }
        };
    }

    /// <summary>
    /// Gera o hash seguro da senha fornecida utilizando o algoritmo BCrypt.
    /// </summary>
    /// <param name="password">Senha original em texto puro.</param>
    /// <returns>Senha criptografada (hash).</returns>
    private string HashPassword(string password)
    {
        // Use um hash robusto (BCrypt recomendado)
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verifica se a senha fornecida corresponde ao hash armazenado.
    /// </summary>
    /// <param name="password">Senha em texto puro informada pelo usuário.</param>
    /// <param name="passwordHash">Hash da senha armazenado no banco.</param>
    /// <returns>True se a senha for válida; false caso contrário.</returns>
    private bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    private User GetUserFromRegisterUser(RegisterRequestDTO requestDTO)
    {
        var userEntity = new User
        {
            CodeUser = Guid.NewGuid().ToString(),
            Email = requestDTO.Email,
            Name = requestDTO.Name?? requestDTO.Email.Substring(0, requestDTO.Email.IndexOf("@")),
            BirthDate = requestDTO.BirthDate,
            PasswordHash = HashPassword(requestDTO.PasswordHash),
            Status = true
        };

        return userEntity;
    }

    #endregion
}