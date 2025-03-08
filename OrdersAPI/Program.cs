using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Services;
using Orders.Domain.Interfaces;
using Orders.Infrastructure;
using Orders.Infrastructure.Repository;
namespace OrdersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CN"));
            });
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            var port= Environment.GetEnvironmentVariable("PORT")?? "8080";
            builder.Services.AddHealthChecks();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()  // Allows any origin
                           .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
                           .AllowAnyHeader(); // Allows any header
                });
            });


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("AllowAll");
            app.UseHealthChecks("/health"); 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                // Show versions in Swagger UI
                //var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                //foreach (var description in provider.ApiVersionDescriptions)
                //{
                //    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                //}
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
