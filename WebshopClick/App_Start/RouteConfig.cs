using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WebshopClick.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("SetCategory", "SetCategory", "~/Pages/WebAdminPages/SettingPages/SetCategory.aspx");
            routes.MapPageRoute("SetGrades", "SetGrades", "~/Pages/WebAdminPages/SettingPages/SetGrades.aspx");
            routes.MapPageRoute("SetPayment", "SetPayment", "~/Pages/WebAdminPages/SettingPages/SetPayment.aspx");
            routes.MapPageRoute("SetStatus", "SetStatus", "~/Pages/WebAdminPages/SettingPages/SetStatus.aspx");
            routes.MapPageRoute("SetTax", "SetTax", "~/Pages/WebAdminPages/SettingPages/SetTax.aspx");
            routes.MapPageRoute("Settings", "Settings", "~/Pages/WebAdminPages/Settings.aspx");
            routes.MapPageRoute("ALogin", "ALogin", "~/Pages/WebAdminPages/AdminLogin.aspx");
            routes.MapPageRoute("AOrders", "AOrders", "~/Pages/WebAdminPages/AdminOrders.aspx");
            routes.MapPageRoute("Statistics", "Statistics", "~/Pages/WebAdminPages/Statistics.aspx");
            routes.MapPageRoute("AProducts", "AProducts", "~/Pages/WebAdminPages/AddProduct.aspx");
        }
    }
}