using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>();

        services.AddScoped<ILanguageRepository, LanguageRepository>();

        return services;
    }
}