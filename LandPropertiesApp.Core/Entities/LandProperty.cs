using Abp.Domain.Entities;
using System.Collections.Generic;

namespace LandPropertiesApp.Entities
{
    public class LandProperty : Entity<int>
    {
        public string Area { get; set; }
        public string UPI { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }

        public int? MortgageId { get; set; }
        public virtual Mortgage Mortgage { get; set; }
    }
}
