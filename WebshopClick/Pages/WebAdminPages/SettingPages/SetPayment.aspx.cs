using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages.SettingPages
{
    public partial class SetPayment : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Payment> PaymentListView_GetData()
        {
            try
            {
                return Service.GetPayment();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningssätt uppgifter skulle hämtas.");
                return null;
            }
        }
        public void PaymentListView_DeleteItem(int PaymentID)
        {
            try
            {
                Service.DeletePayment(PaymentID);
                //Session["Success"] = true;
                Response.RedirectToRoute("Settings");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningssätt uppgiften skulle tas bort.");
            }
        }
        public void PaymentListView_InsertItem(Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdatePayment(payment);
                    //Session["Success"] = true;
                    //Response.RedirectToRoute("Default");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningssätt uppgiften skulle läggas till.");
                }
            }
        }
        public void PaymentListView_UpdateItem(int PaymentID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var payment = Service.GetPaymentByID(PaymentID);
                if (payment == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Betalningssätt hittades inte.", PaymentID));
                    return;
                }

                if (TryUpdateModel(payment))
                {
                    Service.UpdatePayment(payment);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningssätt uppgifter skulle uppdateras.");
            }
        }
    }
}