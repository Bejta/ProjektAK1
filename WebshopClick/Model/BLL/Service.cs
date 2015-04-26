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
        private PaymentDAL _paymentDAL;
        private StatusDAL _statusDAL;
        private GradeDAL _gradeDAL;
        private TaxDAL _taxDAL;


        private CategoryDAL CategoryDAL
        {
            get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); }
        }
        private PaymentDAL PaymentDAL
        {
            get { return _paymentDAL ?? (_paymentDAL = new PaymentDAL()); }
        }
        private StatusDAL StatusDAL
        {
            get { return _statusDAL ?? (_statusDAL = new StatusDAL()); }
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
        public Payment GetPayment(int id)
        {
            return PaymentDAL.GetPaymentById(id);
        }
        public IEnumerable<Payment> GetPayment()
        {
            return PaymentDAL.GetPayment();
        }
        public Payment GetPaymentByID(int id)
        {
            return PaymentDAL.GetPaymentById(id);
        }
        public void DeletePayment(int ID)
        {
            PaymentDAL.DeletePayment(ID);
        }
        public void UpdatePayment(Payment payment)
        {

            ICollection<ValidationResult> validationResults;
            if (!payment.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (payment.PaymentID == 0) // New post if ID is 0!
            {
                PaymentDAL.InsertPayment(payment);
            }
            else
            {
                PaymentDAL.UpdatePayment(payment);
            }

        }
        public Status GetStatus(int id)
        {
            return StatusDAL.GetStatusById(id);
        }
        public IEnumerable<Status> GetStatus()
        {
            return StatusDAL.GetStatus();
        }
        public Status GetStatusByID(int id)
        {
            return StatusDAL.GetStatusById(id);
        }
        public void DeleteStatus(int ID)
        {
            StatusDAL.DeleteStatus(ID);
        }
        public void UpdateStatus(Status status)
        {

            ICollection<ValidationResult> validationResults;
            if (!status.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (status.StatusID == 0) // New post if ID is 0!
            {
                StatusDAL.InsertStatus(status);
            }
            else
            {
                StatusDAL.UpdateStatus(status);
            }
        }
    }
}