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
            Mapper.CreateMap<Owner, OwnerDto>()
                .ForMember(x => x.FullName, o => o.MapFrom(x => string.Format("{0} {1}", x.FirstName, x.LastName)))
                .ForMember(x => x.FullImageUrl, o => o.MapFrom(x => string.IsNullOrEmpty(x.ImageUrl) ? "Images/no_image.gif" : "Images/" + x.ImageUrl));
            Mapper.CreateMap<Owner, LandPropertyOwnerDto>()
                .ForMember(x => x.FullName, o => o.MapFrom(x => string.Format("{0} {1}", x.FirstName, x.LastName)));

            Mapper.CreateMap<LandProperty, LandPropertyDto>()
                .ForMember(x => x.FullImageUrl, o => o.MapFrom(x => string.IsNullOrEmpty(x.ImageUrl) ? "Images/no_image.gif" : "Images/" + x.ImageUrl))
                .ForMember(x => x.LandPropertyFullInfo, o => o.MapFrom(x => string.Format("{0}, {1}", x.Area, x.UPI)));
            Mapper.CreateMap<LandProperty, OwnerLandPropertyDto>()
                .ForMember(x => x.FullImageUrl, o => o.MapFrom(x => string.IsNullOrEmpty(x.ImageUrl) ? "Images/no_image.gif" : "Images/" + x.ImageUrl));
                

            Mapper.CreateMap<Mortgage, MortgageDto>();
            Mapper.CreateMap<LandProperty, MortgageLandPropertyDto>()
                .ForMember(x => x.FullImageUrl, o => o.MapFrom(x => string.IsNullOrEmpty(x.ImageUrl) ? "Images/no_image.gif" : "Images/" + x.ImageUrl));
        }
    }
}
