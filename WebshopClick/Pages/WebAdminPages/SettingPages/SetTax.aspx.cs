using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages.SettingPages
{
    public partial class SetTax : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Tax> TaxListView_GetData()
        {
            try
            {
                return Service.GetTax();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Momsuppgifter skulle hämtas.");
                return null;
            }
        }
        public void TaxListView_DeleteItem(int TaxID)
        {
            try
            {
                Service.DeleteTax(TaxID);
                //Session["Success"] = true;
                Response.RedirectToRoute("Settings");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Momsuppgiften skulle tas bort.");
            }
        }
        public void TaxListView_InsertItem(Tax tax)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdateTax(tax);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Momsuppgiften skulle läggas till.");
                }
            }
        }
        public void TaxListView_UpdateItem(int TaxID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var tax = Service.GetTaxByID(TaxID);
                if (tax == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Moms hittades inte.", TaxID));
                    return;
                }

                if (TryUpdateModel(tax))
                {
                    Service.UpdateTax(tax);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då momsuppgifter skulle uppdateras.");
            }
        }
    }
}