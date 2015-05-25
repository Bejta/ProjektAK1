using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.Logic
{
    public class ShoppingCart
    {
        #region Properties

        public List<CartItem> Items { get; private set; }

        #endregion
       
        
        #region Singleton Implementation

        /// <summary>
        /// http://en.wikipedia.org/wiki/Singleton_pattern
        /// </summary>
        public static ShoppingCart Instance
        {
            get
            {
                if (HttpContext.Current.Session["Cart"] == null)
                {
                    ShoppingCart instance = new ShoppingCart();
                    instance.Items = new List<CartItem>();
                    HttpContext.Current.Session["Cart"] = instance;
                    return instance;
                }
                else
                {
                    return (ShoppingCart)HttpContext.Current.Session["Cart"];
                }
            }
        }

        // The static constructor is called as soon as the class is loaded into memory
        //static ShoppingCart()
        //{
        //    // If the cart is not in the session, create one and put it there
        //    // Otherwise, get it from the session
        //    if (HttpContext.Current.Session["Cart"] == null)
        //    {
        //        Instance = new ShoppingCart();
        //        Instance.Items = new List<CartItem>();
        //        HttpContext.Current.Session["Cart"] = Instance;
        //    }
        //    else
        //    {
        //        Instance = (ShoppingCart)HttpContext.Current.Session["Cart"];
        //    }
        //}
        // A protected constructor ensures that an object can't be created from outside
        protected ShoppingCart() { }

        #endregion

        #region Item Modification Methods
        /**
         * AddItem() - Adds an item to the shopping 
         */
        public void AddItem(int productId)
        {
            // Create a new item to add to the cart
            CartItem newItem = new CartItem(productId);

            // If this item already exists in the list of items, increase the quantity
            // Otherwise, add the new item to the list
            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }
        /**
         * SetItemQuantity() - Changes the quantity of an item in the cart
         */
        public void SetItemQuantity(int productId, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }
        /**
         * RemoveItem() - Removes an item from the shopping cart
         */
        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }
        #endregion
        #region Reporting Methods
        /**
         * GetSubTotal() - returns the total price of all of the items
         *                 before shipping, extra tax etc.
         */
        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
                subTotal += item.TotalPrice;

            return subTotal;
        }
        #endregion

    }
}