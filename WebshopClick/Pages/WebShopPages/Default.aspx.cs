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
        protected void SelectionHasChanged(Object sender, System.EventArgs e)
        {
            
            productList.DataBind();
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
        
        public IEnumerable<Product> ProductListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                
                if (CategoryDropDownList.SelectedValue == "-- Välj kategori --" && TxtSearch.Text=="")
                {
                    return Service.GetProductPageWise(maximumRows, startRowIndex, out totalRowCount);
                    
                }
                else if (TxtSearch.Text != "" && CategoryDropDownList.SelectedValue != "-- Välj kategori --")
                {
                    int fil = Int32.Parse(CategoryDropDownList.SelectedValue);
                    string title = TxtSearch.Text;
                    return Service.GetProductPageWiseByCatIDAndTitle(title, fil, maximumRows, startRowIndex, out totalRowCount);
                }
                else if (TxtSearch.Text == "" && CategoryDropDownList.SelectedValue != "-- Välj kategori --")
                {
                    int fil = Int32.Parse(CategoryDropDownList.SelectedValue);
                    return Service.GetProductPageWiseByCatID(fil, maximumRows, startRowIndex, out totalRowCount);
                }
                else
                {
                    string title = TxtSearch.Text;
                    return Service.GetProductPageWiseByTitle(title, maximumRows, startRowIndex, out totalRowCount);
                }

                
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då produktuppgifter skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
        }

        protected void ImgSearch_Click(object sender, ImageClickEventArgs e)
        {
            productList.DataBind();
        }
    }
}