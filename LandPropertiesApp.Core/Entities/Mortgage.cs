using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Entities
{
    public class Mortgage: Entity<int>
    {
        public int MortgageIdentifier { get; set; }
        public decimal AmountRecieved { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual LandProperty LandProperty { get; set; }
    }
}
