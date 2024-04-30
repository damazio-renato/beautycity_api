using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facens.Business.Models
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }
        protected EntidadeBase()
        {
            Id = new Guid();
        }
    }
}
