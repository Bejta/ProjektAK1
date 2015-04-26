using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    /// <summary>
    /// Class for Category table in the database
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Ett kategori måste anges.")]
        [StringLength(30, ErrorMessage = "Kategoriet kan bestå av som mest 30 tecken.")]
        public string CategoryName { get; set; }
    }
}