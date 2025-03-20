using Deliver.Core.Models;
using Deliver.Core.Repositories;
using Deliver.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Service
{
    public class OrderService: IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }
        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
        public void UpdateOrder(Order order, int id)
        {
            _orderRepository.UpdateOrder(order, id);
        }
        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
        public List<Order> GetBestRoute(List<Order> orders)
        {
            return _orderRepository.GetBestRoute(orders);
        }

    }
}

