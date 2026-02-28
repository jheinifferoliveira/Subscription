using Subscription.Domain.Commons;
using Subscription.Domain.Enums;
using Subscription.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        #region Propriedades

        public string Nome { get; set; } = string.Empty;
        public Email? Email { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public StatusCliente Status { get; set; } = StatusCliente.Ativo;

        #endregion

        #region Relacionamentos

        public ICollection<Assinatura>? Assinaturas { get; set; }

        #endregion
    }

}
