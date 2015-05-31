using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebshopClick.Model.BLL;

namespace WebshopClick.Model.DAL
{
    public class UserDAL:DALBase
    {
        public void UpdateUser(User user)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = user.UserID;
                    cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 20).Value = user.LoginID;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = user.Password;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = user.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 30).Value = user.Address;
                    cmd.Parameters.Add("@Postnumber", SqlDbType.NVarChar, 6).Value = user.Postnumber;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 20).Value = user.City;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 40).Value = user.Email;
                    cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar, 15).Value = user.Telephone;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 15).Value = user.Mobile;
                    cmd.Parameters.Add("@Administrator", SqlDbType.Bit, 2).Value = false;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertUser(User user)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 20).Value = user.LoginID;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = user.Password;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = user.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 30).Value = user.Address;
                    cmd.Parameters.Add("@Postnumber", SqlDbType.NVarChar, 6).Value = user.Postnumber;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 20).Value = user.City;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 40).Value = user.Email;
                    cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar, 15).Value = user.Telephone;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 15).Value = user.Mobile;
                    cmd.Parameters.Add("@Administrator", SqlDbType.Bit, 2).Value = false;
                    
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    user.UserID = (int)cmd.Parameters["@UserID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method that returns all users
        /// </summary>
        /// <returns>List of users objects</returns>
        public IEnumerable<User> GetUser()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var users = new List<User>(200);

                    var cmd = new SqlCommand("appSchema.uspGetUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var UserIDIndex = reader.GetOrdinal("UserID");
                        var LoginIDIndex = reader.GetOrdinal("LoginID");
                        var PasswordIndex = reader.GetOrdinal("Password");
                        var NameIndex = reader.GetOrdinal("Name");
                        var AddressIndex = reader.GetOrdinal("Address");
                        var PostnumberIndex = reader.GetOrdinal("Postnumber");
                        var CityIndex = reader.GetOrdinal("City");
                        var EmailIndex = reader.GetOrdinal("Email");
                        var TelephoneIndex = reader.GetOrdinal("Telephone");
                        var MobileIndex = reader.GetOrdinal("Mobile");
                        var AdministratorIndex = reader.GetOrdinal("Administrator");


                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = reader.GetInt32(UserIDIndex),
                                LoginID = reader.GetString(LoginIDIndex),
                                Password = reader.GetString(PasswordIndex),
                                Name = reader.GetString(NameIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                Email = reader.GetString(EmailIndex),
                                Telephone = reader.GetString(TelephoneIndex),
                                Mobile = reader.GetString(MobileIndex),
                                Administrator = reader.GetBoolean(AdministratorIndex),
                            });
                        }
                    }
                    users.TrimExcess();
                    return users;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting users from the database.");
                }
            }
        }
        /// <summary>
        /// Method to get user by specific id
        /// </summary>
        /// <param name="id">User identity</param>
        /// <returns>Users</returns>
        public User GetUserById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetUserById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var UserIDIndex = reader.GetOrdinal("UserID");
                            var LoginIDIndex = reader.GetOrdinal("LoginID");
                            var PasswordIndex = reader.GetOrdinal("Password");
                            var NameIndex = reader.GetOrdinal("Name");
                            var AddressIndex = reader.GetOrdinal("Address");
                            var PostnumberIndex = reader.GetOrdinal("Postnumber");
                            var CityIndex = reader.GetOrdinal("City");
                            var EmailIndex = reader.GetOrdinal("Email");
                            var TelephoneIndex = reader.GetOrdinal("Telephone");
                            var MobileIndex = reader.GetOrdinal("Mobile");
                            var AdministratorIndex = reader.GetOrdinal("Administrator");


                            return new User
                            {
                                UserID = reader.GetInt32(UserIDIndex),
                                LoginID = reader.GetString(LoginIDIndex),
                                Password = reader.GetString(PasswordIndex),
                                Name = reader.GetString(NameIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                Email = reader.GetString(EmailIndex),
                                Telephone = reader.GetString(TelephoneIndex),
                                Mobile = reader.GetString(MobileIndex),
                                Administrator = reader.GetBoolean(AdministratorIndex),
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
        public User GetUserByLoginID(string loginID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetUserByLoginID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@loginID", loginID);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var UserIDIndex = reader.GetOrdinal("UserID");
                            var LoginIDIndex = reader.GetOrdinal("LoginID");
                            var PasswordIndex = reader.GetOrdinal("Password");
                            var NameIndex = reader.GetOrdinal("Name");
                            var AddressIndex = reader.GetOrdinal("Address");
                            var PostnumberIndex = reader.GetOrdinal("Postnumber");
                            var CityIndex = reader.GetOrdinal("City");
                            var EmailIndex = reader.GetOrdinal("Email");
                            var TelephoneIndex = reader.GetOrdinal("Telephone");
                            var MobileIndex = reader.GetOrdinal("Mobile");
                            var AdministratorIndex = reader.GetOrdinal("Administrator");


                            return new User
                            {
                                UserID = reader.GetInt32(UserIDIndex),
                                LoginID = reader.GetString(LoginIDIndex),
                                Password = reader.GetString(PasswordIndex),
                                Name = reader.GetString(NameIndex),
                                Address = reader.GetString(AddressIndex),
                                Postnumber = reader.GetString(PostnumberIndex),
                                City = reader.GetString(CityIndex),
                                Email = reader.GetString(EmailIndex),
                                Telephone = reader.GetString(TelephoneIndex),
                                Mobile = reader.GetString(MobileIndex),
                                Administrator = reader.GetBoolean(AdministratorIndex),
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
    }
}