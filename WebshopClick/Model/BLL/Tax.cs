using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    /// <summary>
    /// Class for Tax table in the database
    /// </summary>
    public class Tax
    {
        public int TaxID { get; set; }

        [Required(ErrorMessage = "Moms måste anges.")]
        [Range(0.00, 999999999, ErrorMessage = "Ett tal större än 0 måste anges.")]
        public decimal TaxValue { get; set; }
    }
}