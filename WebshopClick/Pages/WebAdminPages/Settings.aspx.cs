using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class Settings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void category_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("SetCategory");
        }

        protected void grade_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("SetGrades");
        }

        protected void tax_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("SetTax");
        }

        protected void payment_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("SetPayment");
        }

        protected void status_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("SetStatus");
        }
    }
}