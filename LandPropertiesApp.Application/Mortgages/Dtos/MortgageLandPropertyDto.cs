using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages.Dtos
{
    public class MortgageLandPropertyDto
    {
        public int Id { get; set; }
        public int UPI { get; set; }
        public string Area { get; set; }
        public string FullImageUrl { get; set; }        
    }
}
