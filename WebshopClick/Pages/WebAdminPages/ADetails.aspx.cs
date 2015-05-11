using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class ADetails : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Product ProductListView_GetData([RouteData] int ProductID)
        {
            try
            {
                Service service = new Service();
                return service.GetProductByID(ProductID);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då produkten hämtades.");
                return null;
            }
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
    }
}