using AutoMapper;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Service.DTOs;

namespace BookCatalog.Core.Data.Mappers;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreatePublisherProfile();
    }

    private void CreatePublisherProfile()
    {
        CreateMap<PublisherDTO, Publisher>().ReverseMap();
    }
}
