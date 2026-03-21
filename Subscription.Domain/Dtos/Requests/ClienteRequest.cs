using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Requests
{
    /// <summary>
    /// DTO para entrada de addos de cliente.
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="email"></param>
    public record ClienteRequest(
        string nome, 
        string email
        );
}
