
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Repository.Implementations;
using NewsAPI.Repository.Interfaces;
using NewsAPI.Service.Implementations;
using NewsAPI.Service.Interfaces;

namespace NewsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //DotNetEnv 
            Env.Load();
            //db DATABASE .env faylinnan gelir
            var connectionString = Environment.GetEnvironmentVariable("DATABASE");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString)); 

            //service repo 
            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddScoped<INewsService, NewsService>();

            //cors
            var cors = Environment.GetEnvironmentVariable("CORS");
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("Frontend", policy =>
                {
                    policy.WithOrigins(cors!)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
    }
}
