using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners.Dtos
{
    public class OwnerLandPropertyDto
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string UPI { get; set; }
        public string LandPropertyFullInfo { get; set; }
        public string FullImageUrl { get; set; }
    }
}
