using Core.Persistence.Paging;
using Devs.Application.Features.OperationClaims.Dtos;

namespace Devs.Application.Features.OperationClaims.Models;

public class OperationClaimListModel : BasePageableModel
{
    public IList<GetListOperationClaimDto> Items { get; set; }
}