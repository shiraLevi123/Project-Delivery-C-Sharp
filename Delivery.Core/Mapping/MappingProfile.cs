using AutoMapper; // ודא שהוספת את ה-using הנכון
using Deliver.Core.DTOs;
using Deliver.Core.Models;

namespace Deliver.Core.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
        }
    }
}

