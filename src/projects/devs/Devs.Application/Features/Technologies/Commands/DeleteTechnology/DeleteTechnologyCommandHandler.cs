using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand,DeletedTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyShouldExistsWhenRequested(request.Id);

        Technology mappedTechnology = _mapper.Map<Technology>(request);
        
        Technology deletedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);

        DeletedTechnologyDto deletedLanguageDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);

        return deletedLanguageDto;
    }
}