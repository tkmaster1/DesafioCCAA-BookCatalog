using System.Text.Json.Serialization;

namespace BookCatalog.Common.Util.DTOs;

public sealed class LoginResponseDTO
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; init; } = string.Empty;

    // Preferível trabalhar com tempo absoluto; se sua API mandar "expiresIn" (segundos),
    // converta na controladora ou no AppService.
    [JsonPropertyName("expiresAtUtc")]
    public DateTimeOffset? ExpiresAtUtc { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("userToken")]
    public UserTokenDTO? UserToken { get; init; }
}

public sealed class UserTokenDTO
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("userName")]
    public string UserName { get; init; } = string.Empty;

    [JsonPropertyName("fileNameImage")]
    public string? FileNameImage { get; init; }

    [JsonPropertyName("claims")]
    public IReadOnlyList<ClaimDTO> Claims { get; init; } = Array.Empty<ClaimDTO>();
}

public sealed class ClaimDTO
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; init; } = string.Empty;
}