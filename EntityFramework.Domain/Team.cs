using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
    public record Team : BaseEntity
    {
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
    }
}
