using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebshopClick.Model.DAL;
using WebshopClick.App_Infrastructure;

namespace WebshopClick.Model.BLL
{
    public class Service
    {
        private CategoryDAL _categoryDAL;


        private CategoryDAL CategoryDAL
        {
            get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); }
        }



        /* CRUD Methods*/

        public Category GetCategory(int id)
        {
            return CategoryDAL.GetCategoryById(id);
        }
        public IEnumerable<Category> GetCategory()
        {
            return CategoryDAL.GetCategory();
        }
        public Category GetCategoryByID(int id)
        {
            return CategoryDAL.GetCategoryById(id);
        }
        public void DeleteCategory(int ID)
        {
            CategoryDAL.DeleteCategory(ID);
        }
        public void UpdateCategory(Category category)
        {

            ICollection<ValidationResult> validationResults;
            if (!category.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (category.CategoryID == 0) // New post if ID is 0!
            {
                CategoryDAL.InsertCategory(category);
            }
            else
            {
                CategoryDAL.UpdateCategory(category);
            }
            
        }
    }
}