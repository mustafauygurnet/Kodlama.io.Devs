using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.Users.Commands.CreateUser;
using Devs.Application.Features.Users.Commands.DeleteUser;
using Devs.Application.Features.Users.Commands.LoginUser;
using Devs.Application.Features.Users.Commands.UpdateUser;
using Devs.Application.Features.Users.Dtos;

namespace Devs.Application.Features.Users.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, CreatedUserForRegisterDto>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();

        CreateMap<User, DeletedUserDto>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();

        CreateMap<User, UpdatedUserDto>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();

        CreateMap<User, LoginedUserDto>().ReverseMap();
        CreateMap<User, LoginUserCommand>().ReverseMap();


    }
}