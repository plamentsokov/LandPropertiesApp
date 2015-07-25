using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.LandProperties.Dtos
{
    /// <summary>
    /// In order to avoid circular mapping in many to many with Automapper
    /// New Dto will be created
    /// Also only the data that is neccessary will be used
    /// </summary>
    public class LandPropertyOwnerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int OwnerUniqueId { get; set; }
    }
}
