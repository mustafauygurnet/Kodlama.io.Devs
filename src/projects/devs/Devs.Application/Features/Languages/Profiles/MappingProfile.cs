using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Devs.Application.Features.Languages.Commands.DeleteLanguage;
using Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Models;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Language, CreatedLanguageDto>().ReverseMap();
        CreateMap<Language, CreateLanguageCommand>().ReverseMap();

        CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
        CreateMap<Language, UpdateLanguageCommand>().ReverseMap();

        CreateMap<Language, DeletedLanguageDto>().ReverseMap();
        CreateMap<Language, DeleteLanguageCommand>().ReverseMap();

        CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
        CreateMap<Language, LanguageListDto>().ReverseMap();

        CreateMap<Language, GetByIdLanguageDto>().ReverseMap();
    }
}