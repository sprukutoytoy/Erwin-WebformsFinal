using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webforms.Models
{
    public class Item
    {
        [Key, ScaffoldColumn(false)]
        public int ItemID { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        public double Weight { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer GetCustomer { get; set; }

    }
}