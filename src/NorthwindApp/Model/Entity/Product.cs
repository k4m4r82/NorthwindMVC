using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindApp.Model.Entity
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public float unit_price { get; set; }
        public int unit_in_stock { get; set; }
        public string qty_per_unit { get; set; }
    }
}
