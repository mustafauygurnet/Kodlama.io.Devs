using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Dtos;

namespace Devs.Application.Features.Technologies.Models;

public class TechnologyListModel : BasePageableModel
{
    public IList<TechnologyListDto> Items { get; set; }
}