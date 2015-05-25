using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    public class ViewOrderDetails
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderID { get; set; }
    }
}