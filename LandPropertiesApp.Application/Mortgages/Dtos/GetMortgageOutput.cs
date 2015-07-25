using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages.Dtos
{
    public class GetMortgageOutput
    {
        public ICollection<MortgageDto> Mortgages { get; set; }
        public MortgageDto SingleMortgage { get; set; }
    }
}
