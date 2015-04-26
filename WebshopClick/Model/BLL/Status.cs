using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    /// <summary>
    /// Class for Status table in the database
    /// </summary>
    public class Status
    {
        public int StatusID { get; set; }

        [Required(ErrorMessage = "En betalning måste anges.")]
        [StringLength(20, ErrorMessage = "Betalningen kan bestå av som mest 20 tecken.")]
        public string StatusType { get; set; }
    }
}