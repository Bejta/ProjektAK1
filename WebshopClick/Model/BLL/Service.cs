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
        private GradeDAL _gradeDAL;
        private TaxDAL _taxDAL;


        private CategoryDAL CategoryDAL
        {
            get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); }
        }
        private GradeDAL GradeDAL
        {
            get { return _gradeDAL ?? (_gradeDAL = new GradeDAL()); }
        }
        private TaxDAL TaxDAL
        {
            get { return _taxDAL ?? (_taxDAL = new TaxDAL()); }
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
        public Grade GetGrade(int id)
        {
            return GradeDAL.GetGradeById(id);
        }
        public IEnumerable<Grade> GetGrade()
        {
            return GradeDAL.GetGrade();
        }
        public Grade GetGradeByID(int id)
        {
            return GradeDAL.GetGradeById(id);
        }
        public void DeleteGrade(int ID)
        {
            GradeDAL.DeleteGrade(ID);
        }
        public void UpdateGrade(Grade grade)
        {

            ICollection<ValidationResult> validationResults;
            if (!grade.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (grade.GradeID == 0) // New post if ID is 0!
            {
                GradeDAL.InsertGrade(grade);
            }
            else
            {
                GradeDAL.UpdateGrade(grade);
            }
        }
        public Tax GetTax(int id)
        {
            return TaxDAL.GetTaxById(id);
        }
        public IEnumerable<Tax> GetTax()
        {
            return TaxDAL.GetTax();
        }
        public Tax GetTaxByID(int id)
        {
            return TaxDAL.GetTaxById(id);
        }
        public void DeleteTax(int ID)
        {
            TaxDAL.DeleteTax(ID);
        }
        public void UpdateTax(Tax tax)
        {

            ICollection<ValidationResult> validationResults;
            if (!tax.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (tax.TaxID == 0) // New post if ID is 0!
            {
                TaxDAL.InsertTax(tax);
            }
            else
            {
                TaxDAL.UpdateTax(tax);
            }
        }
    }
}