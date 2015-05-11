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
        /// <summary>
        /// DropDownList1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList DropDownList1;
        /// <summary>
        /// DropDownList2 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList DropDownList2;

        /// <summary>
        /// PaymentDropDownList control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList PaymentDropDownList;

        
        
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Order> OrderListView_GetData()
        {
            return Service.GetOrder();
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
        public IEnumerable<User> UserDropDownList_GetData()
        {
            try
            {
                return Service.GetUser();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kundsuppgifter skulle hämtas.");
                return null;
            }
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

                    ModelState.AddModelError(String.Empty,
                        String.Format("Beställning hittades inte.", OrderID));
                    return;
                }

                if (TryUpdateModel(order))
                {
                    Service.UpdateOrder(order);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Alogin");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då beställningsuppgifter skulle uppdateras.");
            }
        }


        protected void BtnOrderDetails_Click(object sender, EventArgs e)
        {

        }
    }
}