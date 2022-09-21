using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.Rules;

public class LanguageBusinessRules
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageBusinessRules(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task LanguageNameCanNotDuplicatedWhenInserted(string languageName)
    {
        IPaginate<Language> result =  await _languageRepository.GetListAsync(p => p.Name == languageName);
        if (result.Items.Any()) throw new BusinessException("Language Name Exists");
    }

    public async Task LanguageNameCanNotDuplicatedWhenUpdated(string languageName)
    {
        IPaginate<Language> result = await _languageRepository.GetListAsync(p => p.Name == languageName);
        if (result.Items.Any()) throw new BusinessException("Language Name Exists");
    }

    public async Task LanguageShouldExistsWhenRequested(int languageId)
    {
        Language? result = await _languageRepository.GetAsync(b=>b.Id == languageId);
        if (result is null) throw new BusinessException("Requested Language Does not Exists");
    }
}