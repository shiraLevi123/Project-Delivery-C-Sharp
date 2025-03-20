namespace Deliver.API.Models
{
    public class DeliveryPostModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Express { get; set; }
        public string Roles { get; set; }
    }
}
