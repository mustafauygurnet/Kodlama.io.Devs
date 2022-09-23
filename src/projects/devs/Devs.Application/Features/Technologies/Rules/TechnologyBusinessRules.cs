using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Technologies.Rules;

public class TechnologyBusinessRules
{
    private readonly ITechnologyRepository _technologyRepository;
    private LanguageBusinessRules _languageBusinessRules;

    public TechnologyBusinessRules(ITechnologyRepository technologyRepository, LanguageBusinessRules languageBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task TechnologyNameCanNotDuplicatedWhenInserted(string technologyName)
    {
        var result = await _technologyRepository.GetListAsync(t => t.Name == technologyName);

        if (result.Items.Any()) throw new BusinessException("Technology Name already exists");
    }


    public async Task TechnologyShouldExistsWhenRequested(int technologyId)
    {
        Technology? result = await _technologyRepository.GetAsync(b => b.Id == technologyId);
        if (result is null) throw new BusinessException("Requested Technology Does not Exists");
    }

    public async Task LanguageShouldNotExistsWhenRequested(int technologyId)
    {
        await _languageBusinessRules.LanguageShouldNotExistsWhenRequested(technologyId);
    }
}