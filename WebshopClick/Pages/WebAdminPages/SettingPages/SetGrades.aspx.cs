using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages.SettingPages
{
    public partial class SetGrades : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Grade> GradeListView_GetData()
        {
            try
            {
                return Service.GetGrade();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Betyguppgifter skulle hämtas.");
                return null;
            }
        }
        public void GradeListView_DeleteItem(int GradeID)
        {
            try
            {
                Service.DeleteGrade(GradeID);
                //Session["Success"] = true;
                Response.RedirectToRoute("Settings");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Betyguppgiften skulle tas bort.");
            }
        }
        public void GradeListView_InsertItem(Grade grade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdateGrade(grade);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Betyguppgiften skulle läggas till.");
                }
            }
        }
        public void GradeListView_UpdateItem(int GradeID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var grade = Service.GetGradeByID(GradeID);
                if (grade == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Betyget hittades inte.", GradeID));
                    return;
                }

                if (TryUpdateModel(grade))
                {
                    Service.UpdateGrade(grade);
                    //Session["Success"] = true;
                    Response.RedirectToRoute("Settings");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betyguppgifter skulle uppdateras.");
            }
        }
    }
}