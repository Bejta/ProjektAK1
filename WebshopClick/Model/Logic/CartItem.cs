using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.Logic
{
    /**
         * The CartItem Class
         * 
         * Basically a structure for holding item data
         */
    public class CartItem : IEquatable<CartItem>
    {
        #region Properties

        // A place to store the quantity in the cart
        // This property has an implicit getter and setter.
        public int Quantity { get; set; }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                // To ensure that the Product object will be re-created
                _product = null;
                _productId = value;
            }
        }

        private Product _product = null;
        public Product Prod
        {
            get
            {
                // Lazy initialization - the object won't be created until it is needed
                if (_product == null)
                {
                    _product = new Product();
                }
                return _product;
            }
        }

        public string Name
        {
            get { return Prod.Name; }
        }

        public decimal Price
        {
            get { return Prod.Price; }
        }

        public decimal TotalPrice
        {
            get { return Price * Quantity; }
        }

        #endregion

        // CartItem constructor just needs a productId
        public CartItem(int productId)
        {
            this.ProductId = productId;
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    I used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item.ProductId == this.ProductId;
        }
    }
}