using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.CreateLanguage;

public class
    CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand,
        CreatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public CreateLanguageCommandHandler(ILanguageRepository languageRepository,
        IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request,
        CancellationToken cancellationToken)
    {
        await _languageBusinessRules.LanguageNameCanNotDuplicatedWhenInserted(request.Name);


        Language mappedProgrammingLanguage = _mapper.Map<Language>(request);

        Language createdProgrammingLanguage =
            await _languageRepository.AddAsync(mappedProgrammingLanguage);

        CreatedLanguageDto created = _mapper.Map<CreatedLanguageDto>(createdProgrammingLanguage);

        return created;
    }
}