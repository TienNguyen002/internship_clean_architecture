using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using TitanWeb.Api.Media;
using TitanWeb.Application.Media;
using TitanWeb.Application.Services;
using TitanWeb.Domain.Constants;
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

            builder.Services.Configure<CloudConfiguration>(builder.Configuration.GetSection("CloudinarySettings"));
            builder.Services.AddSingleton(x =>
            {
                var config = x.GetService<IOptions<CloudConfiguration>>().Value;
                return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
            });

            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ISubItemRepository, SubItemRepository>();
            builder.Services.AddScoped<ISubItemService, SubItemService>();
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IRequestFormRepository, RequestFormRepository>();
            builder.Services.AddScoped<IRequestFormService, RequestFormService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICloundinaryService, CloudinaryService>();
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "TitanWeb API v1",
                        Version = "v1.0",
                        Description = ValidateManagements.SwaggerDocDesc,
                        TermsOfService = new Uri(ValidateManagements.SwaggerDocTOS),
                        Contact = new OpenApiContact
                        {
                            Name = ValidateManagements.SwaggerDocContactName,
                            Email = ValidateManagements.SwaggerDocContactEmail
                        },
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            return builder;
        }

        public static WebApplication SetupRequestPipeline(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("TitanWeb");

            return app;
        }
    }
}
