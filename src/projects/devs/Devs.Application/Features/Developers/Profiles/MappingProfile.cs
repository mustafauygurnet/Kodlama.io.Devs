using AutoMapper;
using Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Devs.Application.Features.Developers.Commands.DeleteDeveloper;
using Devs.Application.Features.Developers.Commands.UpdateDeveloper;
using Devs.Application.Features.Developers.Dtos;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Developers.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Developer, CreateDeveloperCommand>().ReverseMap();
        CreateMap<Developer, CreatedDeveloperDto>().ReverseMap();

        CreateMap<Developer, UpdateDeveloperCommand>().ReverseMap();
        CreateMap<Developer, UpdatedDeveloperDto>().ReverseMap();

        CreateMap<Developer, DeleteDeveloperCommand>().ReverseMap();
        CreateMap<Developer, DeletedDeveloperDto>().ReverseMap();
    }
}