using AutoMapper;
using Devs.Application.Features.Developers.Dtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.UpdateDeveloper;

public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand,UpdatedDeveloperDto>
{
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;

    public UpdateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
    {
        _developerRepository = developerRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedDeveloperDto> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
    {
        Developer mappedDeveloper = _mapper.Map<Developer>(request);
        Developer updatedUpdate = await _developerRepository.UpdateAsync(mappedDeveloper);

        UpdatedDeveloperDto updatedDeveloperDto =  _mapper.Map<UpdatedDeveloperDto>(updatedUpdate);

        return updatedDeveloperDto;
    }
}