using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Result;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Data.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateBookProfile();
    }

    private void CreateBookProfile()
    {
        CreateMap<BookDTO, Book>().ReverseMap();
        CreateMap<BookFilterDTO, BookFilter>();
        CreateMap<BookRequestDTO, Book>();

        CreateMap<Book, BookResult>();
        CreateMap<BookResult, Book>();
        CreateMap<BookResultDTO, BookResult>().ReverseMap();

        CreateMap<Pagination<Book>, PaginationDTO<BookDTO>>()
       .AfterMap((source, converted, context) =>
       {
           converted.Result = context.Mapper.Map<List<BookDTO>>(source.Result);
       });
    }
}