using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;
using WebshopClick.Model.Code;
using WebshopClick.Model.Logic;


namespace WebshopClick.Pages.WebShopPages
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                UpdateCart();
            }

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
        protected void SelectionHasChanged(Object sender, System.EventArgs e)
        {    
            productList.DataBind();
        }
        public IEnumerable<Category> CategoryDropDownList_GetData()
        {
            try
            {
                return Service.GetCategory();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kategoriuppgifter skulle hämtas.");
                return null;
            }
        }
        
        public IEnumerable<Product> ProductListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {


                if (CategoryDropDownList.SelectedValue == "-- Välj kategori --" && TxtSearch.Text == "")
                {
                    return Service.GetProductPageWise(maximumRows, startRowIndex, out totalRowCount);
                    
                }
                else if (TxtSearch.Text != "" && CategoryDropDownList.SelectedValue != "-- Välj kategori --")
                {
                    int fil = Int32.Parse(CategoryDropDownList.SelectedValue);
                    string title = TxtSearch.Text;
                    return Service.GetProductPageWiseByCatIDAndTitle(title, fil, maximumRows, startRowIndex, out totalRowCount);
                }
                else if (TxtSearch.Text == "" && CategoryDropDownList.SelectedValue != "-- Välj kategori --")
                {
                    int fil = Int32.Parse(CategoryDropDownList.SelectedValue);
                    return Service.GetProductPageWiseByCatID(fil, maximumRows, startRowIndex, out totalRowCount);
                }
                else
                {
                    string title = TxtSearch.Text;
                    return Service.GetProductPageWiseByTitle(title, maximumRows, startRowIndex, out totalRowCount);
                }

                
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då produktuppgifter skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
        }

        protected void ImgSearch_Click(object sender, EventArgs e)
        {
            productList.DataBind();
        }
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Index");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Profile");
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("ViewCart");
        }

        

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i=0;i < cart.Count;i++)
            {
                if (cart[i].Product.ProductID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        protected void BuyButton_OnClick(object sender, EventArgs e)
        {
            
            Button myButton = (Button)sender;
            int productID = Convert.ToInt32(myButton.CommandArgument.ToString());
            if (Session["Cart"] == null)
            {
                List<Item>cart= new List<Item>();           
                    cart.Add(new Item(this.Service.GetProductByID(productID), 1));

                Session["Cart"]=cart;
                
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
        protected void productlist_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "AddToCart"))
            {
                Button myButton = (Button)sender;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(myButton.CommandArgument.ToString()));
                
                // Redirect the user to view their shopping cart
                Response.RedirectToRoute("ViewCart");
            }
        }   
    }
}