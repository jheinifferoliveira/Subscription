using Subscription.Domain.Commons;
using Subscription.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Entities
{
    public class Plano : BaseEntity
    {
        #region Propriedades

        public string Nome { get; set; } = string.Empty;
        public decimal ValorMensal { get; set; }
        public Periodicidade? Periodicidade { get; set; }
        public bool Ativo { get; set; } = true;

        #endregion

        #region Relacionamentos

        public ICollection<Assinatura>? Assinaturas { get; set; }

        #endregion
    }

}
