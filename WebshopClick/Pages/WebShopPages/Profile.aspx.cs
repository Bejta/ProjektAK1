using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;
using WebshopClick.Model.Code;
using WebshopClick.Model.SecurityLib;

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
            if (Session["Waring"] as bool? == true)
            {
                PlaceHolderCheckFail.Visible = true;
            }
            if (Session["Info"] as bool? == true)
            {
                PlaceHolderCheckOK.Visible = true;
            }

            UpdateCart();
            isLoged();
            if (IsPostBack == true)
            {
                Session["Reg"] = false;
            }

        }

        /// <summary>
        /// Method that sets elements on the page, visible/unvisible in dependence if user is logged
        /// </summary>
        protected void isLoged()
        {
            User user = (User)Session["User"];
            ButtonAdmin.Visible = false;
            UserFormView.Visible = false;
            if (user == null)
            {
                loginform.Visible = true;
                ButtonNewProfile.Visible = true;
                ButtonLogout.Visible = false;
                btnLogin.Text = "Logga in";

                if (Session["reg"] as bool? == true)
                {
                    UserFormView.Visible = true;
                    ButtonNewProfile.Visible = false;
                }
                return;
            }
            else
            {
                if (user.Administrator == true)
                {
                    ButtonAdmin.Visible = true;
                }

                ButtonNewProfile.Visible = false;
                loginform.Visible = false;
                btnLogin.Text = "Hej " + user.LoginID;
                ButtonLogout.Visible = true;
                if (user.Administrator == true)
                {
                    ButtonAdmin.Visible = true;
                }
            }
        }
        /// <summary>
        /// Method that calculates number of items in shoppingcart
        /// </summary>
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
        protected void ButtonNewProfile_Click(object sender, EventArgs e)
        {
            UserFormView.Visible = true;
            ButtonNewProfile.Visible = false;
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Cart"] = null;
            Session["User"] = null;
            isLoged();
            UpdateCart();
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            Session["Info"] = false;
            PlaceHolderCheckOK.Visible = false;
        }
        protected void Close2_Click(object sender, EventArgs e)
        {
            Session["Waring"] = false;
            PlaceHolderCheckFail.Visible = false;
        }
        protected void Close3_Click(object sender, EventArgs e)
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
        protected void btnPage_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("MyPages");
        }
        protected void ButtonAdmin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("alogin");
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            string pass = PasswordLogin.Text;
            string userName = UsernameLogin.Text;
            string password = PasswordLogin.Text + UsernameLogin.Text;
            string psw = PasswordHasher.Hash(password);

            User user = service.GetUserByLoginID(userName);
            if (user != null)
            {
                if (user.Password == psw)
                {
                    Session["User"] = user;
                    isLoged();
                    return;
                }
            }
            PlaceHolder1.Visible = true;
        }
        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            TextBox userName = (TextBox)UserFormView.FindControl("Login");
            Service service = new Service();
            User user = service.GetUserByLoginID(userName.Text);
            if (ModelState.IsValid)
            {
                try
                {
                    Session["Reg"] = true;

                    if (user == null || user.LoginID == "")
                    {

                        PlaceHolderCheckOK.Visible = true;
                    }
                    else
                    {
                        PlaceHolderCheckFail.Visible = true;
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade.");
                }
            }
        }
        protected void LogginButton_Click(object sender, EventArgs e)
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
            //Checks if username already exists in the database
            TextBox userName = (TextBox)UserFormView.FindControl("Login");
            Service service = new Service();
            User checkUser = service.GetUserByLoginID(userName.Text);
            if (checkUser != null)
            {
                Session["Reg"] = true;
                PlaceHolderCheckFail.Visible = true;
                return;
            }

            //Salting password before hashing
            TextBox pswOriginal = (TextBox)UserFormView.FindControl("Password");
            pswOriginal.Text = pswOriginal.Text + userName.Text;
            TextBox pswConfirm = (TextBox)UserFormView.FindControl("ConfirmPassword");
            pswConfirm.Text = pswConfirm.Text + userName.Text;

            //Hashing of password
            string hash1 = PasswordHasher.Hash(pswOriginal.Text);
            string hash2 = PasswordHasher.Hash(pswConfirm.Text);
            if (ModelState.IsValid)
            {
                try
                {
                    user.Password = hash1;
                    service.UpdateUser(user);
                    FlashPlaceHolder.Visible = true;
                    isLoged();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då användare skulle läggas till.");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox pswOriginal = (TextBox)UserFormView.FindControl("Password");
            TextBox userName = (TextBox)UserFormView.FindControl("Login");
        }
    }
}