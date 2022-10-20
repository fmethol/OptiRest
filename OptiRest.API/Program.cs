using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OptiRest.Data;
using OptiRest.Ioc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();


        //builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "OptiRestApi",
                Version = "v1"
            });
        });

        builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );



        var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        Register.RegisterServices(builder.Services, connectionString);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //app.UseSwagger();
        //app.UseSwaggerUI();
        //}
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(
            options => options.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader()
          );

        app.Run();
    }
}