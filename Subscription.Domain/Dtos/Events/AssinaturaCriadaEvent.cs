using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Events
{
    public record AssinaturaCriadaEvent(
        Guid id,
        DateTime dataHora,
        AssinaturaResponse assinatura
        );
}
