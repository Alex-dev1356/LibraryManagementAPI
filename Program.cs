
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Interfaces;
using LibraryManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adding CORS policy to allow requests from any origin, method, and header
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()   
                    );
            });

            // Add services to the container.

            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
             });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<LibraryManagementAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Registering LibraryManagementServices
            builder.Services.AddScoped<ILibraryService, LibraryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAngular");

            app.MapControllers();

            app.Run();
        }
    }
}
