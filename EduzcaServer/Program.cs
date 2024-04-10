
using EduzcaServer.Data;
using EduzcaServer.DataContext;
using EduzcaServer.Repositories;
using EduzcaServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using EduzcaServer.Controllers;

namespace EduzcaServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DATABASE CONNECTION
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DBContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            #endregion

            #region INJECTION DEPENDENCY
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            #endregion



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
