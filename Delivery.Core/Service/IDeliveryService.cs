using Deliver.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Core.Service
{
    public interface IDeliveryService
    {
       public List<Delivery> GetAll();
       public Delivery GetById(int id);
       public void AddDelivery(Delivery delivery);
        public void UpdateDelivery(Delivery delivery, int id);
        public Delivery GetDeliveryByName(string Dname);

        public void DeleteDelivery(int id);
    }
}
