using Devs.Application.Features.Languages.Dtos;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.Languages.GetByIdLanguage;

public class GetByIdLanguageQuery : IRequest<GetByIdLanguageDto>
{
    public int Id { get; set; }
}