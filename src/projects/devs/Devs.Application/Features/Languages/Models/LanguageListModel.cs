using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Dtos;

namespace Devs.Application.Features.Languages.Models;

public class LanguageListModel : BasePageableModel
{
    public IList<LanguageListDto> Items { get; set; }
}