using AutoMapper;
using EHI.Application.AutoMapper;
using EHI.Application.Middleware;
using EHI.Data;
using EHI.Data.GenericRepository;
using EHI.Services.Contracts;
using EHI.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace EHI.Application.Extensions
{
    public static class Application
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IContactService, ContactService>();
        }
        public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddCustomFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(Attributes.ValidateModelAttribute));
            });
        }
        public static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EHI Web API v1.0");
                c.DocumentTitle = "EHI Swagger UI";
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });
        }

        public static void AddSwaggerUICustom(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EHI Web API",
                    Description = "A simple ASP.NET Core Web API for managing contact information.",
                    Contact = new OpenApiContact
                    {
                        Name = "Yash Shah",
                        Email = "yashr.shah@outlook.com",
                        Url = new Uri("https://in.linkedin.com/in/yash3095"),
                    }
                });
            });
        }
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
