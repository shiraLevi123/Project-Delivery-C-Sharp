using Deliver.Core.Models;
using Deliver.Core.Service;
using Deliver.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deliver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<Order> Get()
        {
            return _orderService.GetAll();
        }

        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return _orderService.GetById(id);
        }
       
        [HttpPost]
        public void Post(Order order)
        {
            _orderService.AddOrder(order);
        }

        [HttpPut("{id}")]
        public void Put(Order order, int id)
        {
            _orderService.UpdateOrder(order, id);
        }

        [Authorize(Roles = "manager")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
     
    }
}
