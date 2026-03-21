using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Responses
{
    public record AssinaturaResponse(
        Guid id,
        ClienteResponse cliente,
        PlanoResponse plano,
        DateTime dataInicio,
        decimal valor,
        string status
        );
}
