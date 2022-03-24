using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webforms.Models;

namespace Webforms
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = inputName.Value;
            string phone = inputPhone.Value;

            using (var db = new OrderContext())
            {
                var customers = db.Set<Customer>();
                customers.Add(new Customer { Name = name, Phone = phone });

                db.SaveChanges();
            }

            Response.Redirect("~/Default.aspx");
        }

        public IQueryable<Customer> GetCustomers()
        {
            var _db = new OrderContext();
            IQueryable<Customer> query = _db.Customers;
            return query;
        }

        public void CustomersGrid_UpdateItem(int CustomerID)
        {
            Customer customer = null;
            using (var db = new OrderContext())
            {
                customer = db.Customers.SingleOrDefault(b => b.CustomerID == CustomerID);

                if (customer == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", "Item with id" + CustomerID+ " was not found");
                    return;
                }
                TryUpdateModel(customer);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    db.SaveChanges();
                }
            }
        }

        // Delete
        public void CustomersGrid_DeleteItem(int CustomerID)
        {
            Customer customer = new Customer() { CustomerID = CustomerID };

            using (var db = new OrderContext())
            {
                db.Customers.Attach(customer);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}