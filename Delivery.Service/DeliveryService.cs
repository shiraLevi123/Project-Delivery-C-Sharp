using Deliver.Core.Models;
using Deliver.Core.Repositories;
using Deliver.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public List<Delivery> GetAll()
        {
            return _deliveryRepository.GetAll();
        }

        public Delivery GetById(int id)
        {
            return _deliveryRepository.GetById(id);
        }

        public void AddDelivery(Delivery delivery)
        {
            _deliveryRepository.AddDelivery(delivery);
        }
        public void UpdateDelivery(Delivery delivery, int id)
        {
            _deliveryRepository.UpdateDelivery(delivery, id);
        }
        public void DeleteDelivery(int id)
        {
            _deliveryRepository.DeleteDelivery(id);
        }
        public Delivery GetDeliveryByName(string Dname)
        {
            return _deliveryRepository.GetDeliveryByName(Dname);
        }

        }

    }

