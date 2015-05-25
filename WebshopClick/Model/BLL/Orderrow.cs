using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    public class Orderrow
    {
            [Required(ErrorMessage = "Ett tal måste anges")]
            [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
            public int RowID { get; set; }

            [Required(ErrorMessage = "Ett tal måste anges")]
            [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
            public int OrderID { get; set; }

            [Required(ErrorMessage = "Ett tal måste anges")]
            [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
            public int ProductID { get; set; }

            [Required(ErrorMessage = "Ett tal måste anges")]
            [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
            public int TaxID { get; set; }

            [Required(ErrorMessage = "Ett tal måste anges")]
            [Range(0, Int16.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
            public int Quantity { get; set; }

            [Required(ErrorMessage = "Ett pris måste anges.")]
            [Range(0.00, 999999999, ErrorMessage = "Ett pris större än 0 måste anges.")]
            [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Priset är inte korrekt!")]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "Ett pris måste anges.")]
            [Range(0.00, 999999999, ErrorMessage = "Ett pris större än 0 måste anges.")]
            [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Rabatt är inte korrekt!")]
            public decimal Discount { get; set; }

    }
}