using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class OrderrowDAL:DALBase
    {
        /// <summary>
        /// Method that returns all orderrows
        /// </summary>
        /// <returns>List of orders objects</returns>
        public IEnumerable<Orderrow> GetOrderrow()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var orderrows = new List<Orderrow>(200);

                    var cmd = new SqlCommand("appSchema.uspGetOrderrow", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var RowIDIndex = reader.GetOrdinal("RowID");
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var ProductIDIndex = reader.GetOrdinal("ProductID");
                        var TaxIDIndex = reader.GetOrdinal("TaxID");
                        var QuantityIndex = reader.GetOrdinal("Quantity");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var DiscountIndex = reader.GetOrdinal("Discount");

                        while (reader.Read())
                        {
                            orderrows.Add(new Orderrow
                            {
                                RowID = reader.GetInt32(RowIDIndex),
                                OrderID = reader.GetInt32(OrderIDIndex),
                                ProductID = reader.GetInt32(ProductIDIndex),
                                TaxID = reader.GetInt32(TaxIDIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Discount = reader.GetDecimal(DiscountIndex),
                            });
                        }
                    }
                    orderrows.TrimExcess();
                    return orderrows;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting orderrows from the database.");
                }
            }
        }
        /// <summary>
        /// Updates orderrows
        /// </summary>
        /// <param name="orderrow"></param>
        public void UpdateOrderrow(Orderrow orderrow)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateOrderrow", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@RowID", SqlDbType.Int, 4).Value = orderrow.RowID;
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = orderrow.OrderID;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Value = orderrow.ProductID;
                    cmd.Parameters.Add("@TaxID", SqlDbType.Int, 4).Value = orderrow.TaxID;
                    cmd.Parameters.Add("@Quantity", SqlDbType.SmallInt, 2).Value = orderrow.Quantity;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 9).Value = orderrow.Price;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal, 9).Value = orderrow.Discount;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertOrderrow(Orderrow orderrow)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertOrderrow", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = orderrow.OrderID;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Value = orderrow.ProductID;
                    cmd.Parameters.Add("@TaxID", SqlDbType.Int, 4).Value = orderrow.TaxID;
                    cmd.Parameters.Add("@Quantity", SqlDbType.SmallInt, 2).Value = orderrow.Quantity;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 9).Value = orderrow.Price;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal, 9).Value = orderrow.Discount;
                    cmd.Parameters.Add("@RowID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    orderrow.RowID = (int)cmd.Parameters["@RowID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get orderrow by specific id
        /// </summary>
        /// <param name="id">Orderrow identity</param>
        /// <returns>Orderrows</returns>
        public Orderrow GetOrderrowById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderrowById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RowID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var RowIDIndex = reader.GetOrdinal("RowID");
                            var OrderIDIndex = reader.GetOrdinal("OrderID");
                            var ProductIDIndex = reader.GetOrdinal("ProductID");
                            var TaxIDIndex = reader.GetOrdinal("TaxID");
                            var QuantityIndex = reader.GetOrdinal("Quantity");
                            var PriceIndex = reader.GetOrdinal("Price");
                            var DiscountIndex = reader.GetOrdinal("Discount");


                            return new Orderrow
                            {
                                RowID = reader.GetInt32(RowIDIndex),
                                OrderID = reader.GetInt32(OrderIDIndex),
                                ProductID = reader.GetInt32(ProductIDIndex),
                                TaxID = reader.GetInt32(TaxIDIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Discount = reader.GetDecimal(DiscountIndex),
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
        public IEnumerable<Orderrow> GetOrderrowByOrderID(int orderid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderrowByOrderID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 6).Value = orderid;
                    List<Orderrow> orderrows = new List<Orderrow>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var RowIDIndex = reader.GetOrdinal("RowID");
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var ProductIDIndex = reader.GetOrdinal("ProductID");
                        var TaxIDIndex = reader.GetOrdinal("TaxID");
                        var QuantityIndex = reader.GetOrdinal("Quantity");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var DiscountIndex = reader.GetOrdinal("Discount");


                        while (reader.Read())
                        {
                            orderrows.Add(new Orderrow
                            {
                                RowID = reader.GetInt32(RowIDIndex),
                                OrderID = reader.GetInt32(OrderIDIndex),
                                ProductID = reader.GetInt32(ProductIDIndex),
                                TaxID = reader.GetInt32(TaxIDIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Discount = reader.GetDecimal(DiscountIndex),
                            });
                        }

                    }

                    
                    orderrows.TrimExcess();


                    return orderrows;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public IEnumerable<Orderrow> GetOrderrowByProductID(int productid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderrowByProductID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 6).Value = productid;
                    List<Orderrow> orderrows = new List<Orderrow>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var RowIDIndex = reader.GetOrdinal("RowID");
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var ProductIDIndex = reader.GetOrdinal("ProductID");
                        var TaxIDIndex = reader.GetOrdinal("TaxID");
                        var QuantityIndex = reader.GetOrdinal("Quantity");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var DiscountIndex = reader.GetOrdinal("Discount");


                        while (reader.Read())
                        {
                            orderrows.Add(new Orderrow
                            {
                                RowID = reader.GetInt32(RowIDIndex),
                                OrderID = reader.GetInt32(OrderIDIndex),
                                ProductID = reader.GetInt32(ProductIDIndex),
                                TaxID = reader.GetInt32(TaxIDIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Discount = reader.GetDecimal(DiscountIndex),
                            });
                        }

                    }


                    orderrows.TrimExcess();


                    return orderrows;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public IEnumerable<Orderrow> GetOrderrowByProductIDAndOrderID(int productid,int orderid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderrowByProductIDAndOrderID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 6).Value = productid;
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int, 6).Value = orderid;
                    List<Orderrow> orderrows = new List<Orderrow>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var RowIDIndex = reader.GetOrdinal("RowID");
                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var ProductIDIndex = reader.GetOrdinal("ProductID");
                        var TaxIDIndex = reader.GetOrdinal("TaxID");
                        var QuantityIndex = reader.GetOrdinal("Quantity");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var DiscountIndex = reader.GetOrdinal("Discount");


                        while (reader.Read())
                        {
                            orderrows.Add(new Orderrow
                            {
                                RowID = reader.GetInt32(RowIDIndex),
                                OrderID = reader.GetInt32(OrderIDIndex),
                                ProductID = reader.GetInt32(ProductIDIndex),
                                TaxID = reader.GetInt32(TaxIDIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Discount = reader.GetDecimal(DiscountIndex),
                            });
                        }

                    }


                    orderrows.TrimExcess();


                    return orderrows;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void DeleteOrderrow(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteOrderrow", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@RowID", SqlDbType.Int, 4).Value = ID;
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