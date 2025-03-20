using Deliver.Core.Models;
using Deliver.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(i => i.Id == id);
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void UpdateOrder(Order order, int id)
        {
            var o = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (o != null)
            {
                if (order.Address != null)
                {
                    o.Address = order.Address;
                }

                if (order.Email != null)
                {
                    o.Email = order.Email;
                }

                if (order.CustomerName != null)
                {
                    o.CustomerName = order.CustomerName;
                }

                if (order.NumHouse != null)
                {
                    o.NumHouse = order.NumHouse;
                }
                if (order.City != null)
                {
                    o.City = order.City;
                }
                if (order.DateCreated != null)
                {
                    o.DateCreated = order.DateCreated;
                }
                if (order.DateFinal != null)
                {
                    o.DateFinal = order.DateFinal;
                }
                if (order.Phone != null)
                {
                    o.Phone = order.Phone;
                }
                if (order.DeliverId != null)
                {
                    o.DeliverId = order.DeliverId;
                }                
                    o.Status = order.Status;

                _context.Orders.Update(o);
                _context.SaveChanges();
            }

        }
        public void DeleteOrder(int id)
        {
            var o = _context.Orders.Find(id);
            _context.Remove(o);
            _context.SaveChanges();

        }
        public List<Order> GetBestRoute(List<Order> orders)
        {
            return _context.Orders.ToList(); 
        }

    }
}

