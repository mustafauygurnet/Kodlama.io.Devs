using AutoMapper;
using Devs.Application.Features.Developers.Dtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.CreateDeveloper;

public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, CreatedDeveloperDto>
{
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;

    public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
    {
        _developerRepository = developerRepository;
        _mapper = mapper;
    }

    public async Task<CreatedDeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
    {
        Developer mappedDeveloper = _mapper.Map<Developer>(request);
        Developer createdDeveloper = await _developerRepository.AddAsync(mappedDeveloper);
        CreatedDeveloperDto createdDeveloperDto = _mapper.Map<CreatedDeveloperDto>(createdDeveloper);
        return createdDeveloperDto;
    }
}