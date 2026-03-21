using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Requests
{
    public record AssinaturaRequest(
        Guid clienteId,
        Guid planoId
    );
}
