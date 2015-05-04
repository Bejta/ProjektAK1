using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopClick.Model;
using WebshopClick.Model.BLL;

namespace WebshopClick.Pages.WebAdminPages
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private Images imagesPrivate;
        /// <summary>
        /// If object gallery is not null use it, otherwise make new...
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
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string imagePath = Request.Url.ToString();
            string imageName = Path.GetFileName(imagePath);
            TextBox txt = ProductFormView.FindControl("AddImage") as TextBox;
            if (txt.Text == "")
            {
                txt.Text = "unknown.jpg";
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
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Stream stream = FileUpload.FileContent;
                //Stream stream = FileUpload.FileContent;
                String name = FileUpload.FileName;
                try
                {
                    var image = images.SaveImage(stream, name);
                    isUploaded = true;

                    TextBox txt = ProductFormView.FindControl("AddImage") as TextBox;
                    if (name == "")
                    {
                        txt.Text = "unknown.jpg";
                    }
                    else
                    {
                        txt.Text = name;
                    }

                    //UploadMessage.Visible = true;

                    //Response.Redirect("Default.aspx/" + image);
                }
                catch
                {
                    var CustomValidator1 = new CustomValidator();
                    CustomValidator1.IsValid = false;

                    CustomValidator1.ErrorMessage = "Ett fel inträffade då bilden skulle överföras.";
                    this.Page.Validators.Add(CustomValidator1);
                }
            }
        }
        public Product ProductFormView_GetItem([RouteData] int ProductID)
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
        /// <summary>
        /// Uppdaterar en produkt uppgifter i databasen.
        /// </summary>
        /// <param name="ProductID"></param>
        public void ProductFormView_UpdateItem(int ProductID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var product = Service.GetProductByID(ProductID);
                if (product == null)
                {
                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Produkten med id {0} hittades inte.", ProductID));
                    return;
                }

                if (TryUpdateModel(product))
                {
                    Service.UpdateProduct(product);
                    Response.RedirectToRoute("Aproducts");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då produkten skulle uppdateras.");
            }
        }
    }
}