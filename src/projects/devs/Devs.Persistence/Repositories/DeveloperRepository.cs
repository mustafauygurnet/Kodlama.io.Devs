using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Devs.Persistence.Repositories;

public class DeveloperRepository : EfRepositoryBase<Developer,BaseDbContext>, IDeveloperRepository
{
    public DeveloperRepository(BaseDbContext context) : base(context)
    {
    }

    public Task<int> GetByIdClaimCount(int userId)
    {
        using BaseDbContext context = new();
        var result =  context.Developers.CountAsync(u=>u.UserId == userId);
        return result;
    }
}