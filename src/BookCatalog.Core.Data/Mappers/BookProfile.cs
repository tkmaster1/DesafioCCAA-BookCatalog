using AutoMapper;

namespace BookCatalog.Core.Data.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateBookProfile();
    }

    private void CreateBookProfile()
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