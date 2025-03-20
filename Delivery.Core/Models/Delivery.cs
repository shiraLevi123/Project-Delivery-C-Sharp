using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Core.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address{ get; set; }
        public bool Express { get; set; }
        public string Roles {  get; set; }
        
    }
}
