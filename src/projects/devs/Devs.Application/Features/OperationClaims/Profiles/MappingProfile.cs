using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Models;
using Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

namespace Devs.Application.Features.OperationClaims.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();

        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();

        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();

        CreateMap<OperationClaim, GetByIdOperationClaimDto>().ReverseMap();


        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        CreateMap<OperationClaim, GetListOperationClaimDto>().ReverseMap();
    }
}