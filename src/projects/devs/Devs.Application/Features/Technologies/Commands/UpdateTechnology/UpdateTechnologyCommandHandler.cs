using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyShouldExistsWhenRequested(request.Id);
        await _technologyBusinessRules.LanguageShouldNotExistsWhenRequested(request.LanguageId);

        Technology mappedTechnology = _mapper.Map<Technology>(request);

        Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);

        UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);

        return updatedTechnologyDto;
    }
}