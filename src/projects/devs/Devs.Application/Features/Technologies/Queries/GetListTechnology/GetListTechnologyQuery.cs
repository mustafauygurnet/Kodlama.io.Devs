using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}

public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(
            include: t => t.Include(c => c.Language),
            size: request.PageRequest.PageSize,
            index: request.PageRequest.Page,
            cancellationToken: cancellationToken);

        TechnologyListModel technologyListModel = _mapper.Map<TechnologyListModel>(technologies);

        return technologyListModel;
    }
}