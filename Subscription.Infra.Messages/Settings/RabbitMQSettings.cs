using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Messages.Settings
{
    /// <summary>
    /// Configurações para conexão com o RabbitMQ
    /// </summary>
    public class RabbitMQSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? User { get; set; }
        public string? Pass { get; set; }
        public string? VirtualHost { get; set; }
        public string? QueueName { get; set; }
    }
}
