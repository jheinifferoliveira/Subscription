using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Subscription.Domain.Interfaces.Messages;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Domain.Interfaces.Services;
using Subscription.Domain.Services;
using Subscription.Infra.Data.Contexts;
using Subscription.Infra.Data.Repositories;
using Subscription.Infra.Messages.Publishers;
using Subscription.Infra.Messages.Settings;

namespace Subscription.Api.Extensions
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Método para adicionar as dependências de serviços de domínio.
        /// </summary>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAssinaturaService, AssinaturaService>();

            return services;
        }

        /// <summary>
        /// Método para adicionar as dependências da infraestrutura, como repositórios, contextos, etc.
        /// </summary>        
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Configurar o DbContext do Entity Framework
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    //Obter a string de conexão do arquivo de configuração (appsettings.json)
                    configuration.GetConnectionString("DefaultConnection")
                ));

            //Configurar o UnitofWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //RabbitMQ -> lendo as configurações do appsettings.jsone fazendo o Bind
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));

            //Registrar as configurações
            services.AddSingleton(s =>
            {
                return s.GetRequiredService<IOptions<RabbitMQSettings>>().Value;
            });

            //Adicionar injeção de dependência do Publisher
            services.AddScoped<IEventPublisher, EventPublisher>();

            return services;
        }
    }
}
