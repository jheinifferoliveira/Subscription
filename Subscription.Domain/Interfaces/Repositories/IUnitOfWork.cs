using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();

        public IAssinaturaRepository AssinaturaRepository { get; }
        public IPlanoRepository PlanoRepository { get; }
        public IClienteRepository ClienteRepository { get; }
    }
}
