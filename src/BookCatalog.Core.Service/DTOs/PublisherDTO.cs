namespace BookCatalog.Core.Service.DTOs;

public class PublisherDTO
{
    public int? Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Website { get; set; }

    public bool Status { get; set; }
}