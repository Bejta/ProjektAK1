using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class StatusDAL : DALBase
    {
        /// <summary>
        /// Method that returns all status types
        /// </summary>
        /// <returns>List of status objects</returns>
        public IEnumerable<Status> GetStatus()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var status = new List<Status>(10);

                    var cmd = new SqlCommand("appSchema.uspGetStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var StatusIDIndex = reader.GetOrdinal("StatusID");
                        int StatusTypeIndex = reader.GetOrdinal("StatusType");

                        while (reader.Read())
                        {
                            status.Add(new Status
                            {
                                StatusID = reader.GetInt32(StatusIDIndex),
                                StatusType = reader.GetString(StatusTypeIndex),
                            });
                        }
                    }
                    status.TrimExcess();
                    return status;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting status types from the database.");
                }
            }
        }
        /// <summary>
        /// Updates status
        /// </summary>
        /// <param name="status"></param>
        public void UpdateStatus(Status status)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@StatusID", SqlDbType.Int, 4).Value = status.StatusID;
                    cmd.Parameters.Add("@StatusType", SqlDbType.NVarChar, 20).Value = status.StatusType;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertStatus(Status status)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@StatusType", SqlDbType.NVarChar, 20).Value = status.StatusType;
                    cmd.Parameters.Add("@StatusID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    status.StatusID = (int)cmd.Parameters["@StatusID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get status types by specific id
        /// </summary>
        /// <param name="id">Status indetity</param>
        /// <returns>Status</returns>
        public Status GetStatusById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetStatusById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StatusID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int StatusIDIndex = reader.GetOrdinal("StatusID");
                            int StatusTypeIndex = reader.GetOrdinal("StatusType");


                            return new Status
                            {
                                StatusID = reader.GetInt32(StatusIDIndex),
                                StatusType = reader.GetString(StatusTypeIndex),
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
        public void DeleteStatus(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@StatusID", SqlDbType.Int, 4).Value = ID;
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