using TitanWeb.Api.Extensions;
using TitanWeb.Api.Mapsters;
using TitanWeb.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    //Add services to the container
    builder.ConfigureCors()
        .ConfigureServices()
        .ConfigureSwaggerOpenApi()
        .ConfigureVersioning()
        .ConfigureMapster()
        .ConfigureLogging();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    //Configure the HTTP request pipeline.
    app.SetupRequestPipeline();
    
    //Configure API Controllers
    app.MapControllers();

    app.Run();
}