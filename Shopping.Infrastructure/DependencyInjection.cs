using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Payment.gRPC;
using Shopping.Application.Common.Interfaces;
using Shopping.Domain.Common.Interfaces;
using Shopping.Infrastructure.Authentication.PasswordEncrpytion;
using Shopping.Infrastructure.Authentication.TokenGenerator;
using Shopping.Infrastructure.Common.Persistence;
using Shopping.Infrastructure.Messaging;
using Shopping.Infrastructure.Payment;

namespace Shopping.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionString)
    {
        return services
            .AddServiceBusClient(configuration)
            .AddGrpcClients(configuration)
            .AddAuthentication(configuration)
            .AddPasswordEncryption(configuration)
            .AddPersistence(connectionString);
    }

    private static IServiceCollection AddServiceBusClient (this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new AzureServiceBusSettings();
        configuration.Bind(AzureServiceBusSettings.Section, settings);
        services.AddSingleton(Options.Create(settings));
            
        services.AddAzureClients(
            clientsBuilder =>
            {
                var connectionString = configuration[settings.ConnectionString]
                                       ?? throw new InvalidOperationException("ServiceBus connection string is missing");
                clientsBuilder
                    .AddServiceBusClient(connectionString)
                    .WithName("ServiceBusClient");
            });

        services.AddScoped<IMessagingService, MessagingService>();
        
        return services;
    }
    
    private static IServiceCollection AddGrpcClients (this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new PaymentSettings();
        configuration.Bind(PaymentSettings.Section, settings);
        services.AddSingleton(Options.Create(settings));
        
        services.AddGrpcClient<Cashier.CashierClient>(opt =>
        {
            opt.Address = new Uri(settings.Uri);
        });
        
        services.AddScoped<IPaymentService, PaymentService>();
        
        return services;
    }
    
    private static IServiceCollection AddPersistence (this IServiceCollection services, string connectionString)
    {
        services.AddDbContext(connectionString);
        services.AddRepositories();

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ShoppingDbContext>());
        
        return services;
    }

        
    private static IServiceCollection AddDbContext (this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ShoppingDbContext>(options =>
            options.UseSqlite(connectionString));
        
        return services;
    }

    private static IServiceCollection AddPasswordEncryption (this IServiceCollection services, IConfiguration configuration)
    {
        var passwordEncryptionSettings = new PasswordEncryptionSettings();
        configuration.Bind(PasswordEncryptionSettings.Section, passwordEncryptionSettings);
        services.AddSingleton(Options.Create(passwordEncryptionSettings));
        
        services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();

        return services;
    }
    
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        
        configuration.Bind(JwtSettings.Section, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });
        
        return services;
    }
    
    private static IServiceCollection AddRepositories (this IServiceCollection services)
    {
        return services;
    }
}