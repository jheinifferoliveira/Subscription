using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Subscription.Domain.ValueObjects
{
    public sealed class Email
    {
        public string? Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Email é obrigatório.");

            if (!IsValid(endereco))
                throw new ArgumentException("Email inválido.");

            Endereco = endereco.ToLower();
        }

        private bool IsValid(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }
 }
