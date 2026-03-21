using RabbitMQ.Client;
using Subscription.Domain.Dtos.Events;
using Subscription.Domain.Interfaces.Messages;
using Subscription.Infra.Messages.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Subscription.Infra.Messages.Publishers
{
    /// <summary>
    /// Implementação do Publisher da mensageria
    /// </summary>
    public class EventPublisher(RabbitMQSettings settings) : IEventPublisher
    {
        public async Task PublishAsync(AssinaturaCriadaEvent @event)
        {
            //Configurando a conexão com o servidor do RabbitMQ
            var factory = new ConnectionFactory
            {
                HostName = settings.Host ?? string.Empty,
                Port = settings.Port,
                UserName = settings.User ?? string.Empty,
                Password = settings.Pass ?? string.Empty,
                VirtualHost = settings.VirtualHost ?? string.Empty,
            };

            //Conectando com o RabbitMQ
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            //Criando a fila
            await channel.QueueDeclareAsync(
                    queue: settings.QueueName ?? string.Empty,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

            //Preparando a mensagem para ser gravada na fila
            var json = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(json);

            //Salvar a mensagem na fila
            await channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: settings.QueueName ?? string.Empty,
                    body: body
                );
        }
    }
}
