using AutoMapper;

namespace BookCatalog.Core.Data.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateUsersProfile();
    }

    private void CreateUsersProfile()
    {
        // CreateMap<UserDTO, UserEntity>().ReverseMap();
        // CreateMap<UserFilterDTO, UsersFilter>();
        // CreateMap<UserRequestDTO, UserEntity>();

        // CreateMap<Pagination<UserEntity>, PaginationDTO<UserDTO>>()
        //.AfterMap((source, converted, context) =>
        //{
        //    converted.Result = context.Mapper.Map<List<UserDTO>>(source.Result);
        //});
    }
}