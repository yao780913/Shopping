using Project.Infrastructure;
using Shopping.Api;
using Shopping.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddConfigurations();
    
    var connectionString = builder.Configuration.GetConnectionString("ConnStr");
    
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration, connectionString);
}

var app = builder.Build();
{
    app.UseExceptionHandler();
    
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