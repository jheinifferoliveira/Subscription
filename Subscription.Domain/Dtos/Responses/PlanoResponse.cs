using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Subscription.Domain.Dtos.Responses
{
    public record PlanoResponse(
        Guid id, 
        string nome, 
        decimal valorMensal, 
        string periodicidade
        );
}
