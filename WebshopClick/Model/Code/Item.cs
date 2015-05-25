using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.Code
{
    public class Item
    {
        #region fields

        private Product product;
        private int quantity;

        #endregion

        #region properties
        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
        

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors

        public Item()
        {
            //Empty...
        }
        public Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        #endregion

      
    }
}