using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using System.Net.NetworkInformation;

namespace SchoolOfRobotics.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}