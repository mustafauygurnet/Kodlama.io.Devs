using AutoMapper;
using Devs.Application.Features.Developers.Dtos;
using Devs.Application.Features.Developers.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.CreateDeveloper;

public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, CreatedDeveloperDto>
{
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;
    private readonly DeveloperBusinessRules _developerBusinessRules;

    public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper,
        DeveloperBusinessRules developerBusinessRules)
    {
        _developerRepository = developerRepository;
        _mapper = mapper;
        _developerBusinessRules = developerBusinessRules;
    }

    public async Task<CreatedDeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
    {
        var userId = await _developerBusinessRules.FindUserId();
        await _developerBusinessRules.GithubAddressLimitControl(userId);
        
        Developer mappedDeveloper = _mapper.Map<Developer>(request);
        mappedDeveloper.UserId = userId;
        
        Developer createdDeveloper = await _developerRepository.AddAsync(mappedDeveloper);
        CreatedDeveloperDto createdDeveloperDto = _mapper.Map<CreatedDeveloperDto>(createdDeveloper);
        return createdDeveloperDto;
    }
}