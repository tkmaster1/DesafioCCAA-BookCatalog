using AutoMapper;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Service.DTOs;

namespace BookCatalog.Core.Data.Mappers;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateGenreProfile();
    }

    private void CreateGenreProfile()
    {
        CreateMap<GenreDTO, Genre>().ReverseMap();
    }
}