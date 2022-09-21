using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
{
    public int Id { get; set; }
}

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        await _languageBusinessRules.LanguageShouldExistsWhenRequested(request.Id);

        Language mappedLanguage = _mapper.Map<Language>(request);

        Language language = await _languageRepository.DeleteAsync(mappedLanguage);

        DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(language);

        return deletedLanguageDto;

    }
}