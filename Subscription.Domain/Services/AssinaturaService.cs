using Subscription.Domain.Dtos.Events;
using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Messages;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio de assinatura.
    /// </summary>
    public class AssinaturaService(IUnitOfWork unitOfWork, IEventPublisher publisher) : IAssinaturaService
    {
        public async Task<AssinaturaResponse> CriarAsync(AssinaturaRequest request)
        {
            //Buscar o cliente
            var cliente = await unitOfWork.ClienteRepository.GetByIdAsync(request.clienteId);
            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado.");

            //Buscar o plano
            var plano = await unitOfWork.PlanoRepository.GetByIdAsync(request.planoId);
            if (plano == null)
                throw new ApplicationException("Plano não encontrado.");

            //Verificar se já existe uma assinatura deste cliente com este plano
            var existente = await unitOfWork.AssinaturaRepository
                .CountAsync(a => a.ClienteId == request.clienteId && a.PlanoId == request.planoId);
            if (existente > 0)
                throw new ApplicationException("Este cliente já possui assinatura para o plano informado.");

            //Salvar a assinatura
            var assinatura = new Assinatura
            {
                ClienteId = cliente.Id,
                PlanoId = plano.Id,
                DataInicio = DateTime.Now,
                Valor = plano.ValorMensal
            };

            await unitOfWork.AssinaturaRepository.AddAsync(assinatura);

            var response = ToResponse(assinatura, cliente, plano);

            await publisher.PublishAsync(new AssinaturaCriadaEvent(Guid.NewGuid(), DateTime.Now, response));

            await unitOfWork.SaveChangesAsync();

            return response;
        }

        private AssinaturaResponse ToResponse(Assinatura assinatura, Cliente cliente, Plano plano)
        {
            return new AssinaturaResponse(
                    assinatura.Id,
                    new ClienteResponse(cliente.Id, cliente.Nome, cliente.Email.Endereco, cliente.DataCadastro, cliente.Status.ToString()),
                    new PlanoResponse(plano.Id, plano.Nome, plano.ValorMensal, plano.Periodicidade.ToString()),
                    assinatura.DataInicio,
                    assinatura.Valor,
                    assinatura.Status.ToString()
                );
        }
    }
}
