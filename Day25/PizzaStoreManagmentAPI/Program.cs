using Microsoft.EntityFrameworkCore;
using PizzaStoreManagmentAPI.Context;
using PizzaStoreManagmentAPI.Interfaces;
using PizzaStoreManagmentAPI.Models;
using PizzaStoreManagmentAPI.Repositories;
using PizzaStoreManagmentAPI.Services;
using static PizzaStoreManagmentAPI.Services.UserServices;

namespace PizzaStoreManagmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context Injection
            builder.Services.AddDbContext<PizzaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repository Injections
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, UserCredential>, UserCredentialRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion

            #region Service Injections
            builder.Services.AddScoped<IUserService, UserAuthService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}