namespace BookCatalog.Core.Service.DTOs;

public class UserClaimsDTO
{
    public int? Code { get; set; }

    public string CodeUser { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }
}