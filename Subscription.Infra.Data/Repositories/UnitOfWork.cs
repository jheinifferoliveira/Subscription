using Subscription.Domain.Interfaces.Repositories;
using Subscription.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public IAssinaturaRepository AssinaturaRepository => new AssinaturaRepository(context);

        public IPlanoRepository PlanoRepository => new PlanoRepository(context);

        public IClienteRepository ClienteRepository => new ClienteRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
