using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TInterView.Application.Interfaces;
using TInterView.Application.Services;
using TInterView.Application.Validators;

namespace TInterView.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();
        services.AddFluentValidationAutoValidation();

        return services;
    }
}