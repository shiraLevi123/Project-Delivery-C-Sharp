using AutoMapper;
using Deliver.API.Models;
using Deliver.Core.Models;

namespace Deliver.API.Mapping
{
    public class LoginModelsMappingProfile : Profile
    {
        public LoginModelsMappingProfile()
        {
            CreateMap<DeliveryPostModel, Delivery>();
            CreateMap<DeliveryShortDTO, Delivery>();
        }
    }
}
