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
        private ProductDAL _productDAL;
        private OrderDAL _orderDAL;
        private OrderrowDAL _orderrowDAL;
        private UserDAL _userDAL;
        private ViewOrderDetailsDAL _vieworderdetailsDAL;

        private ViewOrderDetailsDAL ViewOrderDetailsDAL
        {
            get { return _vieworderdetailsDAL ?? (_vieworderdetailsDAL = new ViewOrderDetailsDAL()); }
        }
        private CategoryDAL CategoryDAL
        {
            get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); }
        }
        private OrderDAL OrderDAL
        {
            get { return _orderDAL ?? (_orderDAL = new OrderDAL()); }
        }
        private OrderrowDAL OrderrowDAL
        {
            get { return _orderrowDAL ?? (_orderrowDAL = new OrderrowDAL()); }
        }
        private UserDAL UserDAL
        {
            get { return _userDAL ?? (_userDAL = new UserDAL()); }
        }
        private ProductDAL ProductDAL
        {
            get { return _productDAL ?? (_productDAL = new ProductDAL()); }
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
        public Product GetProduct(int id)
        {
            return ProductDAL.GetProductById(id);
        }
        public IEnumerable<Product> GetProduct()
        {
            return ProductDAL.GetProduct();
        }
        public IEnumerable<Product> GetProductPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ProductDAL.GetProductPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Product> GetProductPageWiseByCatID(int categoryID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ProductDAL.GetProductPageWiseByCatID(categoryID, maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Product> GetProductPageWiseByCatIDAndTitle(string title, int categoryID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ProductDAL.GetProductPageWiseByCatIDAndTitle(title, categoryID, maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Product> GetProductPageWiseByTitle(string title, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ProductDAL.GetProductPageWiseByTitle(title, maximumRows, startRowIndex, out totalRowCount);
        }
        public Product GetProductByID(int id)
        {
            return ProductDAL.GetProductById(id);
        }
        public void DeleteProduct(int ID)
        {
            ProductDAL.DeleteProduct(ID);
        }
        public void UpdateProduct(Product product)
        {

            ICollection<ValidationResult> validationResults;
            if (!product.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (product.ProductID == 0) // New post if ID is 0!
            {
                ProductDAL.InsertProduct(product);
            }
            else
            {
                ProductDAL.UpdateProduct(product);
            }

        }

        public Order GetOrder(int id)
        {
            return OrderDAL.GetOrderById(id);
        }
        public IEnumerable<Order> GetOrder()
        {
            return OrderDAL.GetOrder();
        }
        public IEnumerable<Order> GetOrderPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return OrderDAL.GetOrderPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Order> GetOrderPageWiseByStatus(int statusID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return OrderDAL.GetOrderPageWiseByStatus(statusID, maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Order> GetOrderPageWiseByUserID(int userID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return OrderDAL.GetOrderPageWiseByUserID(userID, maximumRows, startRowIndex, out totalRowCount);
        }

        public Order GetOrderByID(int id)
        {
            return OrderDAL.GetOrderById(id);
        }
        public void DeleteOrder(int ID)
        {
            OrderDAL.DeleteOrder(ID);
        }
        public void UpdateOrder(Order order)
        {
            ICollection<ValidationResult> validationResults;
            if (!order.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (order.OrderID == 0) // New post if ID is 0!
            {
                OrderDAL.InsertOrder(order);
            }
            else
            {
                OrderDAL.UpdateOrder(order);
            }
        }
        public User GetUser(int id)
        {
            return UserDAL.GetUserById(id);
        }
        public IEnumerable<User> GetUser()
        {
            return UserDAL.GetUser();
        }
        public User GetUserByID(int id)
        {
            return UserDAL.GetUserById(id);
        }
        public User GetUserByLoginID(string loginID)
        {
            return UserDAL.GetUserByLoginID(loginID);
        }
        public void UpdateUser(User user)
        {
            ICollection<ValidationResult> validationResults;
            if (!user.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (user.UserID == 0) // New post if ID is 0!
            {
                UserDAL.InsertUser(user);
            }
            else
            {
                UserDAL.UpdateUser(user);
            }
        }
        public IEnumerable<Orderrow> GetOrderrow()
        {
            return OrderrowDAL.GetOrderrow();
        }
        public IEnumerable<ViewOrderDetails> GetOrderrowByOrderViewID(int? orderID)
        {
            return ViewOrderDetailsDAL.GetOrderrowByOrderViewID(orderID);
        }
        public IEnumerable<Orderrow> GetOrderrowByOrderID(int orderID)
        {
            return OrderrowDAL.GetOrderrowByOrderID(orderID);
        }
        public IEnumerable<Orderrow> GetOrderrowByProductID(int productID)
        {
            return OrderrowDAL.GetOrderrowByProductID(productID);
        }
        public IEnumerable<Orderrow> GetOrderrowByProductIDAndOrderID(int productID, int orderID)
        {
            return OrderrowDAL.GetOrderrowByProductIDAndOrderID(productID, orderID);
        }


        public Orderrow GetOrderrowByID(int id)
        {
            return OrderrowDAL.GetOrderrowById(id);
        }
        public void DeleteOrderrow(int ID)
        {
            OrderrowDAL.DeleteOrderrow(ID);
        }
        public void UpdateOrderrow(Orderrow orderrow)
        {

            ICollection<ValidationResult> validationResults;
            if (!orderrow.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (orderrow.RowID == 0) // New post if ID is 0!
            {
                OrderrowDAL.InsertOrderrow(orderrow);
            }
            else
            {
                OrderrowDAL.UpdateOrderrow(orderrow);
            }
        }
    }
}