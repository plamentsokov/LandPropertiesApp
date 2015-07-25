using System.Collections.Generic;
using LandPropertiesApp.Owners.Dtos;
using LandPropertiesApp.Mortgages.Dtos;

namespace LandPropertiesApp.LandProperties.Dtos
{
    public class LandPropertyDto
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string UPI { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl { get; set; }
        public string LandPropertyFullInfo { get; set; }
        public MortgageDto Mortgage { get; set; }
        public ICollection<LandPropertyOwnerDto> Owners { get; set; }

        public LandPropertyDto()
        {
            Owners = new List<LandPropertyOwnerDto>();
        }
    }
}
