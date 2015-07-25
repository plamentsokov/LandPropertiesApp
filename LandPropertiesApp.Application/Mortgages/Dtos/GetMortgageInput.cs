using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages.Dtos
{
    public class GetMortgageInput
    {
        public int MortgageId { get; set; }
        public MortgageDto MortgageToUpdate { get; set; }
    }
}
