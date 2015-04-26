using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebshopClick.Pages.Shared
{
    public partial class WebAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Alogin_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Alogin");
        }

        protected void AdminOrders_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("AOrders");
        }

        protected void AdminProducts_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("AProducts");
        }

        protected void Settings_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Settings");
        }

        protected void Statistics_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Statistics");
        }
    }
}