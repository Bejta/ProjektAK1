using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class GradeDAL:DALBase
    {
        /// <summary>
        /// Method that returns all grades
        /// </summary>
        /// <returns>List of grade objects</returns>
        public IEnumerable<Grade> GetGrade()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var grades = new List<Grade>(10);

                    var cmd = new SqlCommand("appSchema.uspGetGrade", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var GradeIDIndex = reader.GetOrdinal("GradeID");
                        int GradeValueIndex = reader.GetOrdinal("GradeValue");

                        while (reader.Read())
                        {
                            grades.Add(new Grade
                            {
                                GradeID = reader.GetInt32(GradeIDIndex),
                                GradeValue = reader.GetInt32(GradeValueIndex),
                            });
                        }
                    }
                    grades.TrimExcess();
                    return grades;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting grades from the database.");
                }
            }
        }
        /// <summary>
        /// Updates grades
        /// </summary>
        /// <param name="grade"></param>
        public void UpdateGrade(Grade grade)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateGrade", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@GradeID", SqlDbType.Int, 4).Value = grade.GradeID;
                    cmd.Parameters.Add("@GradeValue", SqlDbType.Int, 4).Value = grade.GradeValue;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertGrade(Grade grade)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertGrade", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@GradeValue", SqlDbType.Int, 4).Value = grade.GradeValue;
                    cmd.Parameters.Add("@GradeID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    grade.GradeID = (int)cmd.Parameters["@GradeID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get grade by specific id
        /// </summary>
        /// <param name="id">Grade indetity</param>
        /// <returns>Grade</returns>
        public Grade GetGradeById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetGradeById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GradeID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int GradeIDIndex = reader.GetOrdinal("GradeID");
                            int GradeValueIndex = reader.GetOrdinal("GradeValue");


                            return new Grade
                            {
                                GradeID = reader.GetInt32(GradeIDIndex),
                                GradeValue = reader.GetInt32(GradeValueIndex),
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
        public void DeleteGrade(int ID)
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteGrade", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@GradeID", SqlDbType.Int, 4).Value = ID;
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