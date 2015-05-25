using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.Code;
using WebshopClick.Model.Logic;

namespace WebshopClick.Pages.WebShopPages
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            
            if (Session["Success"] as bool? == true)
            {
                FlashPlaceHolder.Visible = true;
            }
            if (Session["Fail"] as bool? == true)
            {
                PlaceHolder1.Visible = true;
            }
            if (Session["Fail"] as bool? == true)
            {
                PlaceHolder2.Visible = true;
            }
            UpdateCart();
            List<Item> cart = (List<Item>)Session["cart"];
            this.listView.DataSource = cart;
            this.listView.DataBind();

            //if (!IsPostBack)
            //{
            //    //List<Item> cart = (List<Item>)Session["cart"];
                

            //    if ((Session["cart"] != null) && (cart.Count() != 0))
            //    {        
            //            Label TotalCart = (Label)listView.FindControl("TotalCart");
            //            TotalCart.Text = (GetSubTotal(cart)).ToString();
            //    }
            //}
            //this.listView.DataSource = cart;
            //this.listView.DataBind();
            }
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
        protected void Close2_Click(object sender, EventArgs e)
        {
            Session["Info"] = false;
            PlaceHolder2.Visible = false;
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

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hf = (HiddenField)lb.FindControl("HiddenFieldButton");
            int id = Convert.ToInt32(hf.Value);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(isExisting(id));
            Session["cart"] = cart;
            this.listView.DataSource = cart;
            this.listView.DataBind();

            if (cart.Count != 0) {
                Label TotalCart = (Label)listView.FindControl("TotalCart");
                TotalCart.Text = (GetSubTotal(cart)).ToString();
            }
            UpdateCart();
            //if ((cart.Count() != 0) && (Session["cart"] != null))
            //{
            //    int cartTotalQuantity = 0;
            //    foreach (Item item in cart)
            //    {
            //        cartTotalQuantity = cartTotalQuantity + item.Quantity;
            //    }
            //    lblCart.Text = (cartTotalQuantity).ToString();
            //}
            //else
            //{
            //    lblCart.Text = ("0").ToString();
            //}
        }
        protected void UpdateCart()
        {
            int cartTotalQuantity = 0;
            List<Item> cart = (List<Item>)Session["cart"];
            if ((Session["cart"] != null))
            {
                GetSubTotal(cart);
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
            PlaceHolder2.Visible = true;
            return;
        }
        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            TextBox tx= (TextBox)lb.FindControl("QuantityEdit"); 
            HiddenField hf = (HiddenField)lb.FindControl("HiddenFieldButton");
            int id = Convert.ToInt32(hf.Value);
            List<Item> cart = (List<Item>)Session["cart"];
            try
            {
                if (Convert.ToInt32(tx.Text) > 0 && Convert.ToInt32(tx.Text)<999999)
                {
                    cart[isExisting(id)].Quantity = Convert.ToInt32(tx.Text);
                }
                else
                {
                    PlaceHolder1.Visible = true;
                    return;
                }
            }
            catch
            {
                PlaceHolder1.Visible = true;
                return;
            }
            Session["cart"] = cart;
            this.listView.DataSource = cart;
            this.listView.DataBind();
            Label TotalCart = (Label)listView.FindControl("TotalCart");
            TotalCart.Text = (GetSubTotal(cart)).ToString();
            UpdateCart();
            FlashPlaceHolder.Visible = true;
        }
        /// <summary>
        /// Method that calculates total value of shopping cart
        /// </summary>
        /// <param name="cart"></Item></param>
        /// <returns></returns>
        private decimal GetSubTotal(List<Item> cart)
        {
            decimal subTotal = 0;
            foreach (Item item in cart)
                subTotal += item.Product.Price * item.Quantity;

            return subTotal;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Profile");
        }
        protected void ImgSearch_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Index");
        }
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Index");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Proceed");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            //Session["cart"] = null;
            Session["cart"] = cart;
            cart.Clear();
            this.listView.DataSource = cart;
            this.listView.DataBind();
            UpdateCart();
        }
    }
}