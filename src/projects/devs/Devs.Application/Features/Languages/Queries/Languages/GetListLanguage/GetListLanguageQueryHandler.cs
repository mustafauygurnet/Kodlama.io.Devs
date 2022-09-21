using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.Languages.GetListLanguage;

public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Language> languages =
            await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

        LanguageListModel languageListModel = _mapper.Map<LanguageListModel>(languages);

        return languageListModel;
    }
}