using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
    public record League : BaseEntity
    {
        public string Name { get; set; }
    }
}
