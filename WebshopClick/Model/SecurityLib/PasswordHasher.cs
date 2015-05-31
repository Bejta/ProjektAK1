using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WebshopClick.Model.SecurityLib
{
    /// <summary>
    /// Code in this class is user from a book "Beginning ASP:NET E-Commerce in C# 2008"
    /// </summary>
    public class PasswordHasher
    {
        private static SHA1Managed hasher = new SHA1Managed();

        public static string Hash(string password)
        {
            // convert password to byte array
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);
            
            // generate hash from byte array of password
            byte[] passwordHash = hasher.ComputeHash(passwordBytes);
            // convert hash to string
            return Convert.ToBase64String(passwordHash, 0, passwordHash.Length);
        }
    }
}