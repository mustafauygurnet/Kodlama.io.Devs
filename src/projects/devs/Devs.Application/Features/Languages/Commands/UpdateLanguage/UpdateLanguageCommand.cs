using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
        LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        await _languageBusinessRules.LanguageNameCanNotDuplicatedWhenUpdated(request.Name);

        Language mappedLanguage = _mapper.Map<Language>(request);
        Language language = await _languageRepository.UpdateAsync(mappedLanguage);

        UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(language);

        return updatedLanguageDto;
    }
}