using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Response;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Settings;

namespace BookCatalog.Core.Service.Facades.Interfaces;

public interface IAuthFacade : IDisposable
{
    /// <summary>
    /// Método que realiza o Login do usuário na aplicação
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    Task<LoginUserDTO> LoginAsync(LoginRequestDTO requestDTO);

    /// <summary>
    /// Método que realiza o Cadastro do usuário na aplicação
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    Task<LoginUserDTO> RegisterUserAsync(RegisterRequestDTO requestDTO);

    /// <summary>
    /// Método que gera o Token para a aplicação
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <param name="authorizationSettings"></param>
    /// <returns></returns>
    Task<LoginResponseDTO> GerarJwtAsync(string email, AuthorizationSettings authorizationSettings);

    Task<ForgotPasswordResponse> ForgotPassword(string email);
}