using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class OrderDAL:DALBase
    {
        /// <summary>
        /// Method that returns all orders
        /// </summary>
        /// <returns>List of orders objects</returns>
        public IEnumerable<Order> GetOrder()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var orders = new List<Order>(200);

                    var cmd = new SqlCommand("appSchema.uspGetOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var UserIDIndex = reader.GetOrdinal("UserID");
                        var NameIndex = reader.GetOrdinal("Name");
                        var DateIndex = reader.GetOrdinal("Date");
                        var AddressIndex = reader.GetOrdinal("Address");
                        int PostnumberIndex = reader.GetOrdinal("Postnumber");
                        int CityIndex = reader.GetOrdinal("City");
                        int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                        int StatusIDIndex = reader.GetOrdinal("StatusID");


                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                UserID = reader.GetInt32(UserIDIndex),
                                Name = reader.GetString(NameIndex),
                                Date= reader.GetDateTime(DateIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                PaymentID = reader.GetInt32(PaymentIDIndex),
                                StatusID = reader.GetInt32(StatusIDIndex),
                            });
                        }
                    }
                    orders.TrimExcess();
                    return orders;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting orders from the database.");
                }
            }
        }
        /// <summary>
        /// Updates orders
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Order order)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = order.OrderID;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = order.UserID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = order.Name;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime,8).Value = order.Date;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 30).Value = order.Address;
                    cmd.Parameters.Add("@Postnumber", SqlDbType.NVarChar, 6).Value = order.Postnumber;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 20).Value = order.City;
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int, 4).Value = order.PaymentID;
                    cmd.Parameters.Add("@StatusID", SqlDbType.Int, 4).Value = order.StatusID;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertOrder(Order order)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = order.UserID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = order.Name;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime, 8).Value = order.Date;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 30).Value = order.Address;
                    cmd.Parameters.Add("@Postnumber", SqlDbType.NVarChar, 6).Value = order.Postnumber;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 20).Value = order.City;
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int, 4).Value = order.PaymentID;
                    cmd.Parameters.Add("@StatusID", SqlDbType.Int, 4).Value = order.StatusID;
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    order.OrderID = (int)cmd.Parameters["@OrderID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get order by specific id
        /// </summary>
        /// <param name="id">Order identity</param>
        /// <returns>Orders</returns>
        public Order GetOrderById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrderID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var OrderIDIndex = reader.GetOrdinal("OrderID");
                            var UserIDIndex = reader.GetOrdinal("UserID");
                            var NameIndex = reader.GetOrdinal("Name");
                            var DateIndex = reader.GetOrdinal("Date");
                            var AddressIndex = reader.GetOrdinal("Address");
                            int PostnumberIndex = reader.GetOrdinal("Postnumber");
                            int CityIndex = reader.GetOrdinal("City");
                            int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                            int StatusIDIndex = reader.GetOrdinal("StatusID");


                            return new Order
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                UserID = reader.GetInt32(UserIDIndex),
                                Name = reader.GetString(NameIndex),
                                Date = reader.GetDateTime(DateIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                PaymentID = reader.GetInt32(PaymentIDIndex),
                                StatusID = reader.GetInt32(StatusIDIndex),
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
        public IEnumerable<Order> GetOrderPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 6).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 6).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    List<Order> orders = new List<Order>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var UserIDIndex = reader.GetOrdinal("UserID");
                        var NameIndex = reader.GetOrdinal("Name");
                        var DateIndex = reader.GetOrdinal("Date");
                        var AddressIndex = reader.GetOrdinal("Address");
                        int PostnumberIndex = reader.GetOrdinal("Postnumber");
                        int CityIndex = reader.GetOrdinal("City");
                        int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                        int StatusIDIndex = reader.GetOrdinal("StatusID");


                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                UserID = reader.GetInt32(UserIDIndex),
                                Name = reader.GetString(NameIndex),
                                Date = reader.GetDateTime(DateIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                PaymentID = reader.GetInt32(PaymentIDIndex),
                                StatusID = reader.GetInt32(StatusIDIndex),
                            });
                        }

                    }

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    orders.TrimExcess();


                    return orders;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public IEnumerable<Order> GetOrderPageWiseByStatus(int statusID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderPageWiseByStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StatusID", statusID);
                    //cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 6).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 6).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    List<Order> orders = new List<Order>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var UserIDIndex = reader.GetOrdinal("UserID");
                        var NameIndex = reader.GetOrdinal("Name");
                        var DateIndex = reader.GetOrdinal("Date");
                        var AddressIndex = reader.GetOrdinal("Address");
                        int PostnumberIndex = reader.GetOrdinal("Postnumber");
                        int CityIndex = reader.GetOrdinal("City");
                        int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                        int StatusIDIndex = reader.GetOrdinal("StatusID");


                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                UserID = reader.GetInt32(UserIDIndex),
                                Name = reader.GetString(NameIndex),
                                Date = reader.GetDateTime(DateIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                PaymentID = reader.GetInt32(PaymentIDIndex),
                                StatusID = reader.GetInt32(StatusIDIndex),
                            });
                        }

                    }

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    orders.TrimExcess();


                    return orders;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public IEnumerable<Order> GetOrderPageWiseByUserID(int userID, int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderPageWiseByUserID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    //cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 6).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 6).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    List<Order> orders = new List<Order>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var UserIDIndex = reader.GetOrdinal("UserID");
                        var NameIndex = reader.GetOrdinal("Name");
                        var DateIndex = reader.GetOrdinal("Date");
                        var AddressIndex = reader.GetOrdinal("Address");
                        int PostnumberIndex = reader.GetOrdinal("Postnumber");
                        int CityIndex = reader.GetOrdinal("City");
                        int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                        int StatusIDIndex = reader.GetOrdinal("StatusID");


                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                UserID = reader.GetInt32(UserIDIndex),
                                Name = reader.GetString(NameIndex),
                                Date = reader.GetDateTime(DateIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                PaymentID = reader.GetInt32(PaymentIDIndex),
                                StatusID = reader.GetInt32(StatusIDIndex),
                            });
                        }

                    }

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    orders.TrimExcess();


                    return orders;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        
        public void DeleteOrder(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = ID;
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