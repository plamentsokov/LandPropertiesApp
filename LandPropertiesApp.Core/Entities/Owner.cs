using Abp.Domain.Entities;
using System.Collections.Generic;

namespace LandPropertiesApp.Entities
{
    public class Owner: Entity<int>
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public int OwnerUniqueId { get; set; }

        public virtual ICollection<LandProperty> LandProperties { get; set; }

        public Owner()
        {
            LandProperties = new HashSet<LandProperty>();
        }
    }
}
