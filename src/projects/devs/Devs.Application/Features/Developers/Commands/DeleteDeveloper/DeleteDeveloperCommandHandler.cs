using AutoMapper;
using Devs.Application.Features.Developers.Dtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.DeleteDeveloper;

public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand,DeletedDeveloperDto>
{
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;

    public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
    {
        _developerRepository = developerRepository;
        _mapper = mapper;
    }

    public async Task<DeletedDeveloperDto> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
    {
        Developer mappedDeveloper = _mapper.Map<Developer>(request);
        Developer deletedDeveloper = await _developerRepository.DeleteAsync(mappedDeveloper);

        DeletedDeveloperDto deletedDeveloperDto= _mapper.Map<DeletedDeveloperDto>(deletedDeveloper);

        return deletedDeveloperDto;
    }
}