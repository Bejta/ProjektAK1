using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    /// <summary>
    /// Class for Grade table in the database
    /// </summary>
    public class Grade
    {
        public int GradeID { get; set; }

        [Required(ErrorMessage = "Ett betyg måste anges.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal större än 0 måste anges.")]
        public int GradeValue { get; set; }
    }
}