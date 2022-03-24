using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Webforms.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(): base("MVP")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}