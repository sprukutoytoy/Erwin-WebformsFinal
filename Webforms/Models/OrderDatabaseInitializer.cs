using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Webforms.Models
{
    public class OrderDatabaseInitializer : DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            GetCustomers().ForEach(p => context.Customers.Add(p));
            GetItems().ForEach(c => context.Items.Add(c));
        }

        private static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 1,
                    Name = "John Brian",
                    Phone="111111"
                }
            };

            return customers;
        }

        private static List<Item> GetItems()
        {
            var items = new List<Item>
            {
                new Item {
                    ItemID = 1,
                    Title = "Dumbell",
                    Weight = 10,
                    CustomerID = 1
                }
            };

            return items;
        }
    }
}