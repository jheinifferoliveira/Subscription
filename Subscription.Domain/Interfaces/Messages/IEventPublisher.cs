using Subscription.Domain.Dtos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para enviar eventos para mensageria
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Método para enviar um eventi de 'Assinatura criada' para a mensageria
        /// </summary>
        Task PublishAsync(AssinaturaCriadaEvent @event);
    }
}
