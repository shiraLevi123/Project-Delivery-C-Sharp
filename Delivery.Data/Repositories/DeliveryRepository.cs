using Deliver.Core.Models;
using Deliver.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Data.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly HttpClient _httpClient;

        private readonly DataContext _context;
        public DeliveryRepository(DataContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
           
        }
        public List<Delivery> GetAll()
        {
            return _context.Deliveries.ToList();
        }
        public Delivery GetById(int id)
        {
            return _context.Deliveries.FirstOrDefault(i => i.Id == id);
        }
        public void AddDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }
        public void UpdateDelivery(Delivery delivery, int id)
        {
            var d = _context.Deliveries.FirstOrDefault(i => i.Id == id);
            if (d != null)
            {
                if (delivery.Email != null)
                {
                    d.Email = delivery.Email;
                }
                if (delivery.Name != null)
                {
                    d.Name = delivery.Name;
                }
                if (delivery.Password != null)
                {
                    d.Password = delivery.Password;
                }

                if (delivery.Phone != null)
                {
                    d.Phone = delivery.Phone;
                }

                if (delivery.Express != null)
                {
                    d.Express = delivery.Express;
                }
                if (delivery.Address != null)
                {
                    d.Address = delivery.Address;
                }
                if (delivery.Roles != null)
                {
                    d.Roles = delivery.Roles;
                }


                _context.Deliveries.Update(d);
                _context.SaveChanges();
            }
        }
        public void DeleteDelivery(int id)
        {
            var d = _context.Deliveries.Find(id);
            _context.Remove(d);
            _context.SaveChanges();
        }
        public Delivery GetDeliveryByName(string Dname)
        {
            return _context.Deliveries.FirstOrDefault(d => d.Name == Dname);
        }

    }
    }