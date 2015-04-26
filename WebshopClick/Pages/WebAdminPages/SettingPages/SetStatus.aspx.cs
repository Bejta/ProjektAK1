using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages.SettingPages
{
    public partial class SetStatus : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Status> StatusListView_GetData()
        {
            try
            {
                return Service.GetStatus();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status uppgifter skulle hämtas.");
                return null;
            }
        }
        public void StatusListView_DeleteItem(int StatusID)
        {
            try
            {
                Service.DeleteStatus(StatusID);
                //Session["Success"] = true;
                Response.RedirectToRoute("Settings");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status uppgiften skulle tas bort.");
            }
        }
        public void StatusListView_InsertItem(Status status)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdateStatus(status);
                    //Session["Success"] = true;
                    //Response.RedirectToRoute("Default");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status uppgiften skulle läggas till.");
                }
            }
        }
        public void StatusListView_UpdateItem(int StatusID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var status = Service.GetStatusByID(StatusID);
                if (status == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Status hittades inte.", StatusID));
                    return;
                }

                if (TryUpdateModel(status))
                {
                    Service.UpdateStatus(status);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status uppgifter skulle uppdateras.");
            }
        }
    }
}