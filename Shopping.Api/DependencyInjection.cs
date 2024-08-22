using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Shopping.Api;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        var env = builder.Environment;

        builder.Configuration
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables();
        
        return builder;

    }

    public static IServiceCollection AddHttpClient (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(
            "A",
            opt =>
            {
                opt.BaseAddress = new Uri(configuration["ServiceA:BaseUrl"]);
            });
        
        return services;
    }
    
    public static IServiceCollection AddPresentation (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

        services
            .AddEndpointsApiExplorer()
            .AddSwagger()
            .AddProblemDetails()
            .AddHttpContextAccessor();
        
        services.AddHttpClient(configuration);
        
        // TODO: Add the CurrentUserProvider service
        // services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        
        return services;
    }
    
        private static IServiceCollection AddSwagger (this IServiceCollection services)
    {
        services.AddSwaggerGen(
            options =>
            {
                options.TagActionsBy(
                    api =>
                    {
                        if (api.GroupName != null)
                        {
                            return new[] { api.GroupName };
                        }

                        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                        {
                            return new[] { controllerActionDescriptor.ControllerName };
                        }

                        throw new InvalidOperationException("Unable to determine tag for endpoint.");
                    });
                options.DocInclusionPredicate((name, api) => true);
            });

        return services;
    }

    
}