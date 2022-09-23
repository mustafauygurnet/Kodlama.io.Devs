using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Technologies.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
        CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

        CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
        CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

        CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
        CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

        CreateMap<Technology, GetByIdTechnologyDto>()
            .ForMember(t => t.LanguageName, opt => opt.MapFrom(c => c.Language.Name));
        CreateMap<IPaginate<Technology>, GetByIdTechnologyQuery>().ReverseMap();

        CreateMap<Technology, TechnologyListDto>().ForMember(c=>c.LanguageName, opt=>opt.MapFrom(c=>c.Language.Name)).ReverseMap();
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
    }
}