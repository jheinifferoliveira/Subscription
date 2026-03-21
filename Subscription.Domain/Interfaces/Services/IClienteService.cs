using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Services
{
    /// <summary>
    /// Contrato para serviços de dominio de cliente 
    /// </summary>
    public interface IClienteService
    {
        Task<ClienteResponse> CriarAsync(ClienteRequest request);
        Task<ClienteResponse> ObterAsync(string email);
    }
}
