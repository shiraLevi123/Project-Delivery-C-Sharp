using Deliver.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Core.Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order, int id);
        public void DeleteOrder(int id);
        public List<Order> GetBestRoute(List<Order> orders);
    }
}
