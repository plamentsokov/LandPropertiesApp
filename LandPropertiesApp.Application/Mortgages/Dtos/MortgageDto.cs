using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages.Dtos
{
    public class MortgageDto
    {
        public int Id { get; set; }
        public int MortgageIdentifier { get; set; }
        public decimal AmountRecieved { get; set; }
        public DateTime CreatedOn { get; set; }

        public MortgageLandPropertyDto LandProperty { get; set; }
    }
}
