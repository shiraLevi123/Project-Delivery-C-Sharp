using Deliver.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliver.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
