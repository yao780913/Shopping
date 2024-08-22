using Shopping.Api;
using Shopping.Application;
using Shopping.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddConfigurations();
    
    var connectionString = builder.Configuration.GetConnectionString("ConnStr");
    
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration, connectionString);
}

var app = builder.Build();
{
    app.UseExceptionHandler();
    app.AddInfrastructureMiddleware();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}