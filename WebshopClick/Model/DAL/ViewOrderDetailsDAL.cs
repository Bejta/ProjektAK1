using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class ViewOrderDetailsDAL : DALBase
    {
        public IEnumerable<ViewOrderDetails> GetOrderrowByOrderViewID(int? orderid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetOrderrowByOrderIDView", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (orderid == null)
                    {
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int, 6).Value = -1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int, 6).Value = orderid;
                    }
                    
                    List<ViewOrderDetails> vieworderdetails = new List<ViewOrderDetails>(100);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var OrderIDIndex = reader.GetOrdinal("OrderID");
                        var NameIndex = reader.GetOrdinal("Name");
                        var ImageIndex = reader.GetOrdinal("Image");
                        var QuantityIndex = reader.GetOrdinal("Quantity");
                        var PriceIndex = reader.GetOrdinal("Price");

                        while (reader.Read())
                        {
                            vieworderdetails.Add(new ViewOrderDetails
                            {
                                OrderID = reader.GetInt32(OrderIDIndex),
                                Name=reader.GetString(NameIndex),
                                Image=reader.GetString(ImageIndex),
                                Quantity = reader.GetInt16(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex),

                            });
                        }
                    }
                    vieworderdetails.TrimExcess();
                    return vieworderdetails;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

    }
}
