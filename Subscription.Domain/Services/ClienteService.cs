using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Domain.Interfaces.Services;
using Subscription.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Services
{
    public class ClienteService (IUnitOfWork unitOfWork) : IClienteService
    {
        public async Task<ClienteResponse> CriarAsync(ClienteRequest request)
        {
            if(string.IsNullOrEmpty(request.nome) || request.nome.Trim().Length < 6)
                throw new ArgumentException("O nome do cliente é obrigatório e deve ter pelo menos 6 caracteres.");

            var email = new Email(request.email);

            var emailExistente = await unitOfWork.ClienteRepository.CountAsync(c => c.Email.Endereco.Equals(email.Endereco));

            if (emailExistente > 0)
                throw new ArgumentException("O email informado já está cadastrado. Tente outro.");

            var cliente = new Cliente
            {
                Nome = request.nome,
                Email = email
            };

             await unitOfWork.ClienteRepository.AddAsync(cliente);
             await unitOfWork.SaveChangesAsync();

            return ToResponse(cliente);
        }

        public async Task<ClienteResponse> ObterAsync(string email)
        {
             var cliente = await unitOfWork.ClienteRepository.FirstOrDefaultAsync(c => c.Email.Endereco.Equals(email));

            if(cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            return ToResponse(cliente);
        }

        private ClienteResponse ToResponse(Cliente cliente)
        {
            return new ClienteResponse
            (
                cliente.Id,
                cliente.Nome,
                cliente.Email.Endereco,
                cliente.DataCadastro,
                cliente.Status.ToString()
            );
        }
    }
}
