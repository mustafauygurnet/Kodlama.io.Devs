using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Dtos;

namespace Devs.Application.Features.UserOperationClaims.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, GetByIdUserOperationClaimDto>().ReverseMap();
    }
}