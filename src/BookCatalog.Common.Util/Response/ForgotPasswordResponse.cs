namespace BookCatalog.Common.Util.Response;

public class ForgotPasswordResponse
{
    public string CodeUser { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Token { get; set; } = default!;
}