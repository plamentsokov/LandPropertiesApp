using LandPropertiesApp.Entities;
using LandPropertiesApp.LandProperties.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners.Dtos
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int OwnerUniqueId { get; set; }
        public string FullName { get; set; }
        public string FullImageUrl { get; set; }

        public ICollection<OwnerLandPropertyDto> LandProperties { get; set; }

        public OwnerDto()
        {
            LandProperties = new List<OwnerLandPropertyDto>();
        }
    }
}
