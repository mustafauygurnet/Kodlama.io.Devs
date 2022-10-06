using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Dtos;

namespace Devs.Application.Features.UserOperationClaims.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
    }
}