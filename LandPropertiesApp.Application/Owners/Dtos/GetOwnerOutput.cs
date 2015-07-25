using LandPropertiesApp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners.Dtos
{
    public class GetOwnerOutput
    {
        public List<OwnerDto> Owners { get; set; }
        public OwnerDto SingleOwner { get; set; }
    }
}
