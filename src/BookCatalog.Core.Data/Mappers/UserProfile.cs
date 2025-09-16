using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Data.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateUsersProfile();
    }

    private void CreateUsersProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<UserFilterDTO, UserFilter>();
        CreateMap<UserRequestDTO, User>();

        CreateMap<Pagination<User>, PaginationDTO<UserDTO>>()
       .AfterMap((source, converted, context) =>
       {
           converted.Result = context.Mapper.Map<List<UserDTO>>(source.Result);
       });
    }
}