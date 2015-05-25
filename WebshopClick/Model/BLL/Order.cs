using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    public class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(50, ErrorMessage = "Namnet kan bestå av som mest 50 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ett datum måste anges.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "En adress måste anges.")]
        [StringLength(30, ErrorMessage = "Adressen kan bestå av som mest 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ett postnummer måste anges.")]
        [StringLength(6, ErrorMessage = "Postnummret kan bestå av som mest 6 tecken.")]
        public string Postnumber { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(20, ErrorMessage = "Orten kan bestå av som mest 20 tecken.")]
        public string City{ get; set; }

        [Required(ErrorMessage = "Ett betalningssätt måste anges")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ett betalningssätt måste anges.")]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "En statustyp måste anges")]
        [Range(0, Int32.MaxValue, ErrorMessage = "En statustyp måste anges.")]
        public int StatusID { get; set; }
    }
}