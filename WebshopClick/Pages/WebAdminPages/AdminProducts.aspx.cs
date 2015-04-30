using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class AdminProducts : System.Web.UI.Page
    {
        private Images imagesPrivate;
        /// <summary>
        /// If object Images is not null use it, otherwise make new...
        /// </summary>
        public Images images
        {
            get { return imagesPrivate ?? (Images)(imagesPrivate = new Images()); }
        }
        /// <summary>
        /// Holds logical value of session in order to decide on visibility of upload message.
        /// </summary>
        private Boolean isUploaded
        {
            get
            {
                if ((bool?)Session["uploaded"] ?? false)
                {
                    return true;
                }
                return false;
            }
            set
            {
                Session["uploaded"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProductFormView_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
    }
}