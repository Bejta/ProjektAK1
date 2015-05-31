using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Code in this class is user from a book "Beginning ASP:NET E-Commerce in C# 2008"
/// Class will be used in WebshopClick v2.0
/// </summary>

namespace WebshopClick.Model.SecurityLib
{
    public class StringEncryptorException : Exception
    {
        public StringEncryptorException(string message)
            : base(message)
        {
        }
    }
}