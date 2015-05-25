using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class AdminOrders : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Order> OrderListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {

            try
            {
                if (StatusDropDownList.SelectedValue != "-- Välj status --")
                {
                    int fil = Int32.Parse(StatusDropDownList.SelectedValue);
                    return Service.GetOrderPageWiseByStatus(fil, maximumRows, startRowIndex, out totalRowCount);
                }

                return Service.GetOrderPageWise(maximumRows, startRowIndex, out totalRowCount);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då produktuppgifter skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
            //return Service.GetOrderPageWise(maximumRows, startRowIndex, out totalRowCount);
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
        protected void SelectionHasChanged(Object sender, System.EventArgs e)
        {
            //productList.SelectMethod = "ProductListView_GetData";
            OrderListView.DataBind();
        }
       
        public void OrderListView_DeleteItem(int OrderID)
        {
            try
            {
                Service.DeleteOrder(OrderID);
                //Session["Success"] = true;
                Response.RedirectToRoute("Alogin");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då beställningsuppgiften skulle tas bort.");
            }
        }
        
        public void OrderListView_UpdateItem(int OrderID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var order = Service.GetOrderByID(OrderID);
                if (order == null)
                {

                    ModelState.AddModelError(String.Empty,String.Format("Beställning hittades inte.", OrderID));
                    return;
                }

                if (TryUpdateModel(order))
                {
                    Service.UpdateOrder(order);
                    //Session["Success"] = true;
                    //Response.RedirectToRoute("Alogin");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då beställningsuppgifter skulle uppdateras.");
            }
        }


        protected void BtnOrderDetails_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            HiddenField hf = (HiddenField)lb.FindControl("HiddenField1");
            int id = Convert.ToInt32(hf.Value);
            Response.RedirectToRoute("AdminOrderdetails", new { OrderID = id });
        }
    }
}