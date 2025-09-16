using AutoMapper;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Service.DTOs;

namespace BookCatalog.Core.Data.Mappers;

public class UserClaimsProfile : Profile
{
    public UserClaimsProfile()
    {
        CreateUserClaimsProfile();
    }

    private void CreateUserClaimsProfile()
    {
        CreateMap<UserClaimsDTO, UserClaims>().ReverseMap();
    }
}