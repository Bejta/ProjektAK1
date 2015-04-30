using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class ProductDAL:DALBase
    {
        /// <summary>
        /// Method that returns all products
        /// </summary>
        /// <returns>List of products objects</returns>
        public IEnumerable<Product> GetProduct()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var products = new List<Product>(200);

                    var cmd = new SqlCommand("appSchema.uspGetProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var ProductIDIndex = reader.GetOrdinal("ProductID");
                        int ProductNameIndex = reader.GetOrdinal("Name");       
                        int PriceIndex = reader.GetOrdinal("Price");
                        int DescriptionIndex = reader.GetOrdinal("Description");
                        int ImageIndex = reader.GetOrdinal("Image");
                        int CategoryIDIndex = reader.GetOrdinal("CategoryID");
                        

                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductID = reader.GetInt32(ProductIDIndex),
                                Name = reader.GetString(ProductNameIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Description = reader.GetString(DescriptionIndex),
                                Image = reader.GetString(ImageIndex),
                                CategoryID = reader.GetInt32(CategoryIDIndex),
                                
                            });
                        }
                    }
                    products.TrimExcess();
                    return products;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting products from the database.");
                }
            }
        }
        /// <summary>
        /// Updates products
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Value = product.ProductID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 40).Value = product.Name;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 9).Value = product.Price;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Value = product.Description;
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 50).Value = product.Image;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = product.CategoryID;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertProduct(Product product)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 40).Value = product.Name;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 9).Value = product.Price;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Value = product.Description;
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 50).Value = product.Image;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = product.CategoryID;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    product.ProductID = (int)cmd.Parameters["@ProductID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get product by specific id
        /// </summary>
        /// <param name="id">Product identity</param>
        /// <returns>Product</returns>
        public Product GetProductById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetProductById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var ProductIDIndex = reader.GetOrdinal("ProductID");
                            int ProductNameIndex = reader.GetOrdinal("Name");
                            int PriceIndex = reader.GetOrdinal("Price");
                            int DescriptionIndex = reader.GetOrdinal("Description");
                            int ImageIndex = reader.GetOrdinal("Image");
                            int CategoryIDIndex = reader.GetOrdinal("CategoryID");


                            return new Product
                            {
                                ProductID = reader.GetInt32(ProductIDIndex),
                                Name = reader.GetString(ProductNameIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Description = reader.GetString(DescriptionIndex),
                                Image = reader.GetString(ImageIndex),
                                CategoryID = reader.GetInt32(CategoryIDIndex),
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void DeleteProduct(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Value = ID;
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}