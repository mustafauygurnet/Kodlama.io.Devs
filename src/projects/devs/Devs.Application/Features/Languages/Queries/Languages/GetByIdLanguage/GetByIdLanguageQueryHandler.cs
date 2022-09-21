using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.Languages.GetByIdLanguage;

public class
    GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery,
        GetByIdLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private LanguageBusinessRules _languageBusinessRules;

    public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository,
        IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request,
        CancellationToken cancellationToken)
    {
        await _languageBusinessRules.LanguageShouldExistsWhenRequested(request.Id);


        var programmingLanguage = await _languageRepository.GetAsync(p => p.Id == request.Id);

        GetByIdLanguageDto getByIdProgrammingLanguageDto = _mapper.Map<GetByIdLanguageDto>(programmingLanguage);

        return getByIdProgrammingLanguageDto;
    }
}