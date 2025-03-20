using Deliver.Core.Models;

namespace Deliver.API.Models
{
    public class DeliveryShortDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Express { get; set; }
        public string Roles { get; set; }
        public DeliveryShortDTO(Delivery delivery)
        {
            Name = delivery.Name;
            Email = delivery.Email;
            Phone = delivery.Phone;
            Address = delivery.Address;
            Express = delivery.Express;
            Roles = delivery.Roles;
        }
        public DeliveryShortDTO() { }
    }
}
