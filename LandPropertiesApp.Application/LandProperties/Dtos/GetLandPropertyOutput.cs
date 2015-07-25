using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.LandProperties.Dtos
{
    public class GetLandPropertyOutput
    {
        public List<LandPropertyDto> LandPropertiesList { get; set; }
        public LandPropertyDto SingleLandProperty { get; set; }
    }
}
