using AutoMapper;
using Deliver.API.Models;
using Deliver.Core.Models;
using Deliver.Core.Service;
using Deliver.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Deliver.Core.Models.Deliver.Core.Models.GoogleMapsApi.Models;

using IGoogleMapsService = Deliver.Core.Service.IGoogleMapsService;

using Deliver.Data.Migrations;
using System.Text;
using Deliver.Core.Repositories;
using Deliver.Data.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deliver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DeliveriesController : ControllerBase

    {
        private readonly IDeliveryService _deliveryService;
        private readonly IGoogleMapsService _googleMapsService;
        private readonly IMapper _mapper;
        private readonly IDeliveryRepository _IdeliveryRepository;


        public DeliveriesController(
          IDeliveryService deliveryService,
          IMapper mapper,
          IGoogleMapsService googleMapsService,
          IDeliveryRepository IdeliveryRepository)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
            _googleMapsService = googleMapsService;
            _IdeliveryRepository = IdeliveryRepository;
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public List<Delivery> Get()
        {
            return _deliveryService.GetAll();
        }

        [HttpGet("{id}")]

        public Delivery GetById(int id)
        {
            return _deliveryService.GetById(id);
        }

        [HttpPost]
         [Authorize(Roles = "manager")]
        public void Post(DeliveryPostModel delivery)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(delivery.Password);
            delivery.Password = hashedPassword;
            _deliveryService.AddDelivery(_mapper.Map<Delivery>(delivery));
        }

        [HttpPut("{id}")]
        public void Put(Delivery delivery, int id)
        {
            _deliveryService.UpdateDelivery(delivery, id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public void Delete(int id)
        {
            _deliveryService.DeleteDelivery(id);
        }


        [HttpGet("optimized-route")]
        public async Task<IActionResult> GetOptimizedRoute(
             [FromQuery] string origin,
             [FromQuery] string destination,
             [FromQuery] string[] waypoints)
        {
            var route = await _googleMapsService.GetOptimizedRouteAsync(origin, destination, waypoints);
            if (route == null)
                return BadRequest("Failed to get route");

            return Ok(route);
        }


    }
}


