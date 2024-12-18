using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Entities.Base
{
    public class BaseEntity<T> : DomainEntity
    {
        public virtual T Id { get; set; } = default!;

    }
}
