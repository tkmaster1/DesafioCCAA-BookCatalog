using BookCatalog.Core.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookCatalog.Core.Service.Helper;

/// <summary>
/// Helper responsável por gerar a identidade de claims do usuário.
/// </summary>
public static class ClaimsHelper
{
    /// <summary>
    /// Gera uma ClaimsIdentity com informações do usuário e suas roles.
    /// </summary>
    /// <param name="user">Usuário autenticado.</param>
    /// <param name="roles">Lista de roles atribuídas ao usuário.</param>
    /// <returns>Objeto ClaimsIdentity preenchido com as claims do usuário.</returns>
    public static async Task<ClaimsIdentity> GetClaimsUser(User user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.CodeUser),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
        };

        foreach (var role in roles)
            claims.Add(new Claim("role", role));

        var identity = new ClaimsIdentity();
        identity.AddClaims(claims);
        return identity;
    }

    private static long ToUnixEpochDate(DateTime date) =>
        (long)Math.Round((date.ToUniversalTime() -
            new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
}