using AutoMapper;
using LandPropertiesApp.LandProperties.Dtos;
using LandPropertiesApp.Entities;
using LandPropertiesApp.Owners.Dtos;
using LandPropertiesApp.Mortgages.Dtos;

namespace LandPropertiesApp
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            //I specified mapping for AssignedPersonId since NHibernate does not fill Task.AssignedPersonId
            //If you will just use EF, then you can remove ForMember definition.
            Mapper.CreateMap<Owner, OwnerDto>();
            Mapper.CreateMap<LandProperty, LandPropertyDto>()
                .ForMember(x => x.FullImageUrl, o => o.MapFrom(x => string.IsNullOrEmpty(x.ImageUrl) ? "Images/no_image.gif" : "Images/" + x.ImageUrl));
            Mapper.CreateMap<Mortgage, MortgageDto>();    
        }
    }
}
