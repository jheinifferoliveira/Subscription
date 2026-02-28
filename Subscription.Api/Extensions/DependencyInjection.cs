using Microsoft.EntityFrameworkCore;
using Subscription.Infra.Data.Contexts;

namespace Subscription.Api.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    //Obter a string de conexão do arquivo de configuração (appsettings.json)
                    configuration.GetConnectionString("DefaultConnection")
                ));

            return services;
        }
    }
}
