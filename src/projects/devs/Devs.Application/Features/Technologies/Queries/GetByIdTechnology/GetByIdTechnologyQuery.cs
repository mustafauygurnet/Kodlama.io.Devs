using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Queries.GetByIdTechnology;

public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
{
    public int Id { get; set; }
}

public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper,
        TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyShouldExistsWhenRequested(request.Id);


        IPaginate<Technology> getTechnology = await _technologyRepository.GetListAsync(
            include: t => t.Include(l => l.Language),
            predicate: t => t.Id == request.Id,
            cancellationToken: cancellationToken);

        GetByIdTechnologyDto getByIdTechnologyDto = _mapper.Map<GetByIdTechnologyDto>(getTechnology.Items[0]);

        return getByIdTechnologyDto;
    }
}