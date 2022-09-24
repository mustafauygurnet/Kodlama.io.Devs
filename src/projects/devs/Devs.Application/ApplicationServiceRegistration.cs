using System.Reflection;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Features.Users.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<LanguageBusinessRules>();
        services.AddScoped<TechnologyBusinessRules>();
        services.AddScoped<OperationClaimBusinessRules>();
        services.AddScoped<UserOperationClaimBusinessRules>();
        services.AddScoped<UserBusinessRules>();

        return services;
    }
}