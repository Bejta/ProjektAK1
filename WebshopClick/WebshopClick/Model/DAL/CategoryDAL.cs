using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class CategoryDAL : DALBase
    {
        /// <summary>
        /// Method that returns all categories
        /// </summary>
        /// <returns>List of category objects</returns>
        public IEnumerable<Category> GetCategory()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var categories = new List<Category>(10);

                    var cmd = new SqlCommand("appSchema.uspGetCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var CategoryIDIndex = reader.GetOrdinal("CategoryID");
                        int CategoryNameIndex = reader.GetOrdinal("CategoryName");

                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                CategoryID = reader.GetInt32(CategoryIDIndex),
                                CategoryName = reader.GetString(CategoryNameIndex),
                            });
                        }
                    }
                    categories.TrimExcess();
                    return categories;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting categories from the database.");
                }
            }
        }
        /// <summary>
        /// Updates category
        /// </summary>
        /// <param name="category"></param>
        public void UpdateCategory(Category category)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = category.CategoryID;
                    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 20).Value = category.CategoryName;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertCategory(Category category)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 30).Value = category.CategoryName;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    category.CategoryID = (int)cmd.Parameters["@CategoryID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get category by specific id
        /// </summary>
        /// <param name="id">Category indetity</param>
        /// <returns>Category</returns>
        public Category GetCategoryById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetCategoryById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int CategoryIDIndex = reader.GetOrdinal("CategoryID");
                            int CategoryNameIndex = reader.GetOrdinal("CategoryName");


                            return new Category
                            {
                                CategoryID = reader.GetInt32(CategoryIDIndex),
                                CategoryName = reader.GetString(CategoryNameIndex),
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
        public void DeleteCategory(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = ID;
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