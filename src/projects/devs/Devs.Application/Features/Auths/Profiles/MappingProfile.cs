using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Devs.Application.Features.Auths.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User,UserForRegisterDto>().ReverseMap();
    }
}