using BookCatalog.Core.Service.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookCatalog.Core.Service.Helper;

public static class TokenBuilder
{
    /// <summary>
    /// Gera um token JWT com base nas claims e nas configurações fornecidas.
    /// </summary>
    /// <param name="identity">Identidade do usuário (claims).</param>
    /// <param name="settings">Configurações JWT.</param>
    /// <returns>Token JWT como string.</returns>
    public static string GenerateToken(ClaimsIdentity identityClaims, AuthorizationSettings authorizationSettings)
    {
        var key = Encoding.ASCII.GetBytes(authorizationSettings.Secret);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identityClaims,
            Issuer =  authorizationSettings.Issuer,
            Audience = authorizationSettings.ValidOn,
            Expires =  DateTime.UtcNow.AddDays(authorizationSettings.ExpirationDays), //DateTime.UtcNow.AddMinutes(expirationInMinutes),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}