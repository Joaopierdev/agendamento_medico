using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AgendamentoMedico
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AgendamentosDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicialização do Swagger
                InitializeSwagger(app);
            }


            app.MapControllers();

            app.Run();
        }
    }
}
