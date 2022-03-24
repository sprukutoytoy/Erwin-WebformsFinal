using Webforms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webforms
{
    public partial class ItemList : Page
    {
        private double? parcelTotal = 0;
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ItemGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                parcelTotal = null;
            }
            else
            {
                Label weight = (Label)e.Row.FindControl("LblWeight");

                if (weight != null)
                {
                    double subTotal = double.Parse(weight.Text);
                    parcelTotal += subTotal;
                }
            }
        }

        protected void ItemGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if(tot != null)
            {
                tot.Text = parcelTotal.ToString();
                if (parcelTotal > 50)
                {
                    Label1.Text = "N/A";
                    Label2.Text = "Reject";
                }
                else if (parcelTotal > 30)
                {
                    Label1.Text = "$" + 10 * parcelTotal;
                    Label2.Text = "Heavy";
                }
                else if (parcelTotal > 20)
                {
                    Label1.Text = "$" + 15 * parcelTotal;
                    Label2.Text = "Large";
                }
                else if (parcelTotal > 10)
                {
                    Label1.Text = "$" + 20 * parcelTotal;
                    Label2.Text = "Medium";
                }
                else
                {
                    Label1.Text = "$" + 25 * parcelTotal;
                    Label2.Text = "Small";
                }
            }
            
        }

        public IQueryable<Item> GetItems([QueryString("customerId")] int? customerId)
        {
            var _db = new OrderContext();
            IQueryable<Item> query = _db.Items;
            if (customerId.HasValue && customerId > 0)
            {
                query = query.Where(p => p.CustomerID == customerId);
            }

            return query;
        }

        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["CustomerId"].ToString());
            string title = inputTitle.Value;
            double weight = double.Parse(inputWeight.Value);

            using (var db = new OrderContext())
            {
                var customers = db.Set<Item>();
                customers.Add(new Item { Title = title, Weight = weight, CustomerID = id });

                db.SaveChanges();
            }

            Response.Redirect("~/ItemList.aspx?CustomerId=" + id);
        }

        public void ItemGrid_UpdateItem(int ItemID)
        {
            Item item = null;
            using (var db = new OrderContext())
            {
                item = db.Items.SingleOrDefault(b => b.ItemID == ItemID);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", "Item with id" + ItemID + " was not found");
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }

        public void ItemGrid_DeleteItem(int ItemID)
        {
            Item parcel = new Item() { ItemID = ItemID };

            using (var db = new OrderContext())
            {
                db.Items.Attach(parcel);
                db.Items.Remove(parcel);
                db.SaveChanges();
            }
            tot.Text = null;
            Label1.Text = null;
            Label2.Text = null;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}