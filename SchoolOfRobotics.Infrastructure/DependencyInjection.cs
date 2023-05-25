using Microsoft.Extensions.DependencyInjection;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Infrastructure.Repositories;

namespace SchoolOfRobotics.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChildrenCollectionRepository, ChildrenCollectionRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
		return services;
    }
}