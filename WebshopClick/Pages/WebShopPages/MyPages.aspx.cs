using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebShopPages
{
    public partial class MyPages : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            if (user == null || user.UserID == 1)
            {
                Response.RedirectToRoute("Profile");
            }
            isLoged();
        }
        protected void isLoged()
        {
            User user = (User)Session["User"];
            ButtonAdmin.Visible = false;

            if (user == null)
            {
                btnLogin.Text = "Logga in";
                return;
            }
            else
            {
                if (user.Administrator == true)
                {
                    ButtonAdmin.Visible = true;
                }
                btnLogin.Text = "Hej " + user.LoginID;

                if (user.Administrator == true)
                {
                    ButtonAdmin.Visible = true;
                }
            }
        }
        public IEnumerable<Status> StatusDropDownList_GetData()
        {
            try
            {
                return Service.GetStatus();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status typ skulle hämtas.");
                return null;
            }
        }
        protected void BtnOrderDetails_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hf = (HiddenField)lb.FindControl("HiddenField1");
            int id = Convert.ToInt32(hf.Value);

            //Get index of item that contain clicked button
            var item = (ListViewItem)lb.NamingContainer;
            int i = item.DataItemIndex;
            OrderListView.SelectedIndex = i;

            IEnumerable<ViewOrderDetails> details = Service.GetOrderrowByOrderViewID(id);
            this.OrderrowListView.DataSource = details;
            OrderrowListView.DataBind();
            GetSubTotal();

        }
        public IEnumerable<WebshopClick.Model.BLL.Order> OrderListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                User user = (User)Session["User"];
                int id = user.UserID;

                return Service.GetOrderPageWiseByUserID(id, maximumRows, startRowIndex, out totalRowCount);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då produktuppgifter skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
        }
        protected void GetSubTotal()
        {
            decimal subTotal = 0;
            Label TotalCart = (Label)OrderrowListView.FindControl("TotalCart");

            foreach (ListViewItem lstItem in OrderrowListView.Items)
            {
                Label TotalItem = (Label)lstItem.FindControl("total");
                string x = TotalItem.Text;
                if (x != "")
                {
                    decimal subTotalTemp = Convert.ToDecimal(x);
                    subTotal += subTotalTemp;
                }
            }

            if (TotalCart != null)
                TotalCart.Text = (subTotal).ToString();
        }
        public IEnumerable<ViewOrderDetails> OrderrowListView_GetData(int? OrderID)
        {           
            return Service.GetOrderrowByOrderViewID(OrderID);
        }
        public IEnumerable<Payment> PaymentDropDownList_GetData()
        {
            try
            {
                return Service.GetPayment();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningstyp skulle hämtas.");
                return null;
            }
        }
        protected void ButtonAdmin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("alogin");
        }
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("index");
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("ViewCart");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Profile");
        }

        protected void ImgSearch_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("index");
        }
    }
}