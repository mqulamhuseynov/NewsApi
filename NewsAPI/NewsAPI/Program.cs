
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;

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
            
            Env.Load();
            //db
            var connectionString = Environment.GetEnvironmentVariable("DATABASE");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString)); 

            //service repo 


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
