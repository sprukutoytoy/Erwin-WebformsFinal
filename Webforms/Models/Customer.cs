using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webforms.Models
{
    public class Customer
    {
        [Key, ScaffoldColumn(false)]
        public int CustomerID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}