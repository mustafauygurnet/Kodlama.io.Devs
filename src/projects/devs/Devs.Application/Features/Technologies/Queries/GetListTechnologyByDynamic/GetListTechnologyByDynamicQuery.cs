using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;

public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
}

public class
    GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public GetListTechnologyByDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request,
        CancellationToken cancellationToken)
    {
        IPaginate<Technology> technologies = await _technologyRepository.GetListByDynamicAsync(
            dynamic: request.Dynamic,
            include: c => c.Include(c => c.Language),
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        TechnologyListModel technologyListModel = _mapper.Map<TechnologyListModel>(technologies);

        return technologyListModel;
    }
}