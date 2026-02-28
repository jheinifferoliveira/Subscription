using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Commons
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
