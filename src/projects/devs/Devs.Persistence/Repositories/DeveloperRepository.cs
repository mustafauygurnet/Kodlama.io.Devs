using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories;

public class DeveloperRepository : EfRepositoryBase<Developer,BaseDbContext>, IDeveloperRepository
{
    public DeveloperRepository(BaseDbContext context) : base(context)
    {
    }
}