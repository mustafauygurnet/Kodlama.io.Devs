using Core.Security.JWT;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using Devs.Application.Services.UserService;
using Devs.Persistence.Contexts;
using Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LanguageDbConnectionString")));

        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ITechnologyRepository, TechnologyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}