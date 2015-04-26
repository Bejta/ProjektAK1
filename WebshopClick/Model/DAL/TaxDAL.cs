using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class TaxDAL:DALBase
    {
        /// <summary>
        /// Method that returns all taxes
        /// </summary>
        /// <returns>List of tax objects</returns>
        public IEnumerable<Tax> GetTax()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var taxes = new List<Tax>(10);

                    var cmd = new SqlCommand("appSchema.uspGetTax", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var TaxIDIndex = reader.GetOrdinal("TaxID");
                        int TaxValueIndex = reader.GetOrdinal("TaxValue");

                        while (reader.Read())
                        {
                            taxes.Add(new Tax
                            {
                                TaxID = reader.GetInt32(TaxIDIndex),
                                TaxValue = reader.GetDecimal(TaxValueIndex),
                            });
                        }
                    }
                    taxes.TrimExcess();
                    return taxes;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting taxes from the database.");
                }
            }
        }
        /// <summary>
        /// Updates taxes
        /// </summary>
        /// <param name="tax"></param>
        public void UpdateTax(Tax tax)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateTax", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@TaxID", SqlDbType.Int, 4).Value = tax.TaxID;
                    cmd.Parameters.Add("@TaxValue", SqlDbType.Decimal).Value = tax.TaxValue;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertTax(Tax tax)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertTax", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@TaxValue", SqlDbType.Decimal ).Value = tax.TaxValue;
                    cmd.Parameters.Add("@TaxID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    tax.TaxID = (int)cmd.Parameters["@TaxID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get taxes by specific id
        /// </summary>
        /// <param name="id">Tax indetity</param>
        /// <returns>Tax</returns>
        public Tax GetTaxById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetTaxById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaxID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int TaxIDIndex = reader.GetOrdinal("TaxID");
                            int TaxValueIndex = reader.GetOrdinal("TaxValue");


                            return new Tax
                            {
                                TaxID = reader.GetInt32(TaxIDIndex),
                                TaxValue = reader.GetDecimal(TaxValueIndex),
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
        public void DeleteTax(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteTax", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@TaxID", SqlDbType.Int, 4).Value = ID;
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