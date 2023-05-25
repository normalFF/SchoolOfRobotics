using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Quartz;
using SchoolOfRobotics.Api.Setup;
using SchoolOfRobotics.Application;
using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Contracts;
using SchoolOfRobotics.Infrastructure;
using SchoolOfRobotics.Infrastructure.Authentication;
using SchoolOfRobotics.Infrastructure.BackgroundProcess;
using SchoolOfRobotics.Infrastructure.Context;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddMappings();
    builder.Services.AddInfrastructure();
}

builder.Services.AddDbContext<ApplicationDbContext>(
    (serviseProvider, optionsBuilder) =>
    {
        optionsBuilder.UseNpgsql();
    });

builder.Services.AddQuartz(configure =>
{
    var jobKey = new JobKey(nameof(ProcessOutBoxMessages));

    configure
        .AddJob<ProcessOutBoxMessages>(jobKey)
        .AddTrigger(trigger => trigger.ForJob(jobKey)
        .WithSimpleSchedule(
            schedule => schedule.WithIntervalInSeconds(60).RepeatForever()));

    configure.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddTransient<IAuthorizationHandler, TokenAuthorizationHandler>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
