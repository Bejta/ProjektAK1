using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;
using WebshopClick.Model.Code;

namespace WebshopClick.Pages.WebShopPages
{
    public partial class Profile : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {

            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Success"] as bool? == true)
            {
                FlashPlaceHolder.Visible = true;
            }
            if (Session["Fail"] as bool? == true)
            {
                PlaceHolder1.Visible = true;
            }
            UpdateCart();
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
                }
                else
                {
                    lblCart.Text = "0";
                }
            }
            
            return;
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            Session["Success"] = false;
            FlashPlaceHolder.Visible = false;
        }
        protected void Close1_Click(object sender, EventArgs e)
        {
            Session["Fail"] = false;
            PlaceHolder1.Visible = false;
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("ViewCart");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        protected void ImgSearch_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("index");
        } 
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("index");
        }
        public void UserFormView_InsertItem(WebshopClick.Model.BLL.User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.UpdateUser(user);
                    FlashPlaceHolder.Visible = true;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då användare skulle läggas till.");
                }
            }
        }            
    }
}