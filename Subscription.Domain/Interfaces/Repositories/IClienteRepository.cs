using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente, Guid>
    {
    }
}
