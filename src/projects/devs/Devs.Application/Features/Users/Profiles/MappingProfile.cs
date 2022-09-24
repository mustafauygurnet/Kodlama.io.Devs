using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.Users.Commands.CreateUser;
using Devs.Application.Features.Users.Dtos;

namespace Devs.Application.Features.Users.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, CreatedUserForRegisterDto>();
        CreateMap<User, CreateUserCommand>();
    }
}