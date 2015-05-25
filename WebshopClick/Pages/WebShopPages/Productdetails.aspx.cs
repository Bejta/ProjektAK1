using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;
using WebshopClick.Model.Code;

namespace WebshopClick.Pages.WebShopPages
{
    public partial class Productdetails : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void ImgSearch_Click(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                UpdateCart();
            }
        }
        public Product ProductListView_GetData([RouteData] int ProductID)
        {
            try
            {
                Service service = new Service();
                return service.GetProductByID(ProductID);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då produkten hämtades.");
                return null;
            }
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        protected void UpdateCart()
        {
            int cartTotalQuantity = 0;
            List<Item> cart = (List<Item>)Session["cart"];
            if ((Session["cart"] != null))
            {
                if ((cart.Count() != 0))
                {

                    foreach (Item item in cart)
                    {
                        cartTotalQuantity = cartTotalQuantity + item.Quantity;
                    }
                    lblCart.Text = (cartTotalQuantity).ToString();
                    return;
                }
            }
            lblCart.Text = "0";
            return;
        }
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Index");
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("ViewCart");
        }
        protected void BuyButton_OnClick(object sender, EventArgs e)
        {

            Button myButton = (Button)sender;
            Service service = new Service();
            int productID = Convert.ToInt32(RouteData.Values["ProductID"]);
            if (Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(this.Service.GetProductByID(productID), 1));

                Session["Cart"] = cart;

            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(productID);
                if (index == -1)
                {
                    cart.Add(new Item(this.Service.GetProductByID(productID), 1));
                }
                else
                {
                    cart[index].Quantity++;
                }
                Session["Cart"] = cart;
            }
            Response.RedirectToRoute("ViewCart");
        }
        //public IEnumerable<Category> CategoryDropDownList_GetData()
        //{
        //    try
        //    {
        //        return Service.GetCategory();
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kategoriuppgifter skulle hämtas.");
        //        return null;
        //    }
        //}
    }
}