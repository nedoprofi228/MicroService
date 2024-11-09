using Microsoft.Extensions.DependencyInjection;
using EFZipContext;
using Microsoft.EntityFrameworkCore;

namespace NewWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<ArchiveContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("ToDbString"));
                });
                
            var app = builder.Build();
            
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}