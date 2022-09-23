using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyNameCanNotDuplicatedWhenInserted(request.Name);
        await _technologyBusinessRules.LanguageShouldNotExistsWhenRequested(request.LanguageId);

        Technology mappedTechnology = _mapper.Map<Technology>(request);

        Technology createdTechnology =  await _technologyRepository.AddAsync(mappedTechnology);

        CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);

        return createdTechnologyDto;

    }
}