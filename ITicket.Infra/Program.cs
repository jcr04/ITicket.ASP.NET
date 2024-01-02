using ITicket.Infra.Data;
using ITicket.Infra.Factory;
using ITicket.Infra.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ITicket.Infra;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Obter a configuração
                IConfiguration configuration = hostContext.Configuration;

                // Configuração do DbContext para o PostgreSQL
                services.AddDbContext<YourDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("YourDbConnectionString")));

                // Configuração dos Repositórios
                services.AddScoped<IEventEfRepository, EventEfRepository>();
                services.AddScoped<IEventRepositoryFactory, EventRepositoryFactory>();
                // Adicione outros repositórios conforme necessário

                // Adicione outros serviços conforme necessário

                // ...
            });
}
