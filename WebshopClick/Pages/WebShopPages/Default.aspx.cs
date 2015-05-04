using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebShopPages
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Product> ProductListView_GetData()
        {
            try
            {
                return Service.GetProduct();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då produktuppgifter skulle hämtas.");
                return null;
            }
        }
    }
}