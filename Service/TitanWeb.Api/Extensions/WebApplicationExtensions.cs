using Microsoft.EntityFrameworkCore;
using Serilog;
using TitanWeb.Api.Media;
using TitanWeb.Application.Services;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;
using TitanWeb.Infrastructure.Contexts;
using TitanWeb.Infrastructure.Repositories;

namespace TitanWeb.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<TitanWebContext>(options =>
                options.UseSqlServer(
            builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IRequestFormRepository, RequestFormRepository>();
            builder.Services.AddScoped<IRequestFormService, RequestFormService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubItemRepository, SubItemRepository>();
            builder.Services.AddScoped<ISubItemService, SubItemService>();
            builder.Services.AddScoped<IButtonRepository, ButtonRepository>();
            builder.Services.AddScoped<IButtonService, ButtonService>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            var _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.AddSerilog(_logger);
            return builder;
        }

        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("TitanWeb", policyBuilder =>
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplication SetupRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("TitanWeb");

            return app;
        }
    }
}
