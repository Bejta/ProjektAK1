using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class Categories : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Category> CategoryListView_GetData()
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
        public void CategoryListView_DeleteItem(int CategoryID)
        {
            try
            {
                Service.DeleteCategory(CategoryID);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kategoriuppgiften skulle tas bort.");
            }
        }
        public void CategoryListView_InsertItem(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.UpdateCategory(category);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kategoriuppgiften skulle läggas till.");
                }
            }
        }
        public void CategoryListView_UpdateItem(int CategoryID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var category = Service.GetCategoryByID(CategoryID);
                if (category == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Kategori hittades inte.", CategoryID));
                    return;
                }

                if (TryUpdateModel(category))
                {
                    Service.UpdateCategory(category);
                    Response.RedirectToRoute("Settings");// PRG - POST->Redirect->GET
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då linjeuppgifter skulle uppdateras.");
            }
        }
    }

}