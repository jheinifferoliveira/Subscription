using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Repositories
{
    public class ClienteRepository(AppDbContext context)
        : BaseRepository<Cliente, Guid>(context), IClienteRepository
    {

    }
}