using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class
    GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery,
        GetByIdUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;

    public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request,
        CancellationToken cancellationToken)
    {
        UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);

        GetByIdUserOperationClaimDto getByIdUserOperationClaimDto =
            _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);

        return getByIdUserOperationClaimDto;
    }
}