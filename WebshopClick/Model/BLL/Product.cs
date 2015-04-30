using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(30, ErrorMessage = "Produktsnamnet kan bestå av som mest 40 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ett pris måste anges.")]
        [Range(0.00, 999999999, ErrorMessage = "Ett pris större än 0 måste anges.")]
        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Priset är inte korrekt!") ]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges.")]
        [StringLength(200, ErrorMessage = "Beskrivning kan bestå av som mest 200 tecken.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ett bildnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Ett bildnamn kan bestå av som mest 50 tecken.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Ett kategori måste anges")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")] 
        public int CategoryID { get; set; }

    }
}