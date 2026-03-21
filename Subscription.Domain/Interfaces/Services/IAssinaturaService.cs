using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Services
{
    public interface IAssinaturaService
    {
        Task<AssinaturaResponse> CriarAsync(AssinaturaRequest request);
    }
}
