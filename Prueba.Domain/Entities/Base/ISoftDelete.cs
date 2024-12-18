using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Entities.Base
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
    }

}
