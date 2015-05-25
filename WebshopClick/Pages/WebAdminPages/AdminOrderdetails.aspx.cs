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
    
    public partial class AdminOrderdetails : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSubTotal();
        }
        protected void GetSubTotal()
        {
            decimal subTotal = 0;
            Label TotalCart = (Label)OrderrowListView.FindControl("TotalCart");
            
            foreach (ListViewItem lstItem in OrderrowListView.Items)
            {
                Label TotalItem = (Label)lstItem.FindControl("total");
                string x = TotalItem.Text;
                if (x != "")
                {
                    decimal subTotalTemp = Convert.ToDecimal(x);
                    subTotal += subTotalTemp;
                }
                
            }       
           
            if (TotalCart!=null)
             TotalCart.Text = (subTotal).ToString();
        }
        protected void btnHem_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("AOrders");
        }
        public Order OrderFormView_GetData([RouteData] int OrderID)
        {
            try
            {
                Service service = new Service();
                return service.GetOrderByID(OrderID);
                
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då beställning hämtades.");
                return null;
            }
        }
        //private decimal GetSubTotal(Service cart)
        //{
        //    decimal subTotal = 0;
        //    for (int i = 0; i < cart.GetOrderrowByOrderViewID(orderID).Count<>;i++ )
        //        foreach (Service item in cart)
        //            subTotal += item.GetOrderrowByOrderID * item.Quantity;

        //    return subTotal;
        //}
        public IEnumerable<Status> StatusDropDownList_GetData()
        {
            try
            {
                return Service.GetStatus();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då status typ skulle hämtas.");
                return null;
            }
        }
        public IEnumerable<ViewOrderDetails> OrderrowListView_GetData([RouteData] int OrderID)
        {
            return Service.GetOrderrowByOrderViewID(OrderID);
        }

        public IEnumerable<Payment> PaymentDropDownList_GetData()
        {
            try
            {
                return Service.GetPayment();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då betalningstyp skulle hämtas.");
                return null;
            }
        }
        
    }
}