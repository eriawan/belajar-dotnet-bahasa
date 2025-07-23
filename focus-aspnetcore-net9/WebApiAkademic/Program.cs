
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApiAkademic.Data;

namespace WebApiAkademic;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddSqlServer<AcademicRegistrationDbContext>(builder.Configuration.GetConnectionString("Academik"));
        builder.Services.AddDbContext<AcademicRegistrationDbContext>(optionsAction =>
        {
            optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("Academik"));
        });

        // Add services to the container.
        builder.Services.AddProblemDetails();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Ensure database exists
        app.CreateDbIfNotExists();

        // Configure the HTTP request pipeline.
        app.UseExceptionHandler();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
