using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClick.Model.BLL
{
    public class User
    {

        [Required(ErrorMessage = "Ett userID måste anges")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Ett heltal måste anges.")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Ett användarsnamn adress måste anges.")]
        [StringLength(20, ErrorMessage = "Användarsnamn kan bestå av som mest 20 tecken.")]
        public string LoginID { get; set; }

        [Required(ErrorMessage = "Ett lösenord måste anges.")]
        [StringLength(100, ErrorMessage = "Lösenordet kan bestå av som mest 100 tecken.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(50, ErrorMessage = "Namnet kan bestå av som mest 50 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "En adress måste anges.")]
        [StringLength(30, ErrorMessage = "Adressen kan bestå av som mest 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ett postnumermåste anges.")]
        [StringLength(6, ErrorMessage = "Postnumret kan bestå av som mest 6 tecken.")]
        public string Postnumber { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(20, ErrorMessage = "Orten kan bestå av som mest 20 tecken.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ett email måste anges.")]
        [StringLength(40, ErrorMessage = "Emailet kan bestå av som mest 40 tecken.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "En telefon måste anges.")]
        [StringLength(15, ErrorMessage = "Telefon kan bestå av som mest 15 tecken.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "En mobil måste anges.")]
        [StringLength(15, ErrorMessage = "Mobilen kan bestå av som mest 15 tecken.")]
        public string Mobile { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Ett värde 0/1 måste anges.")] //Validation of boolean datatype (bit in MS Sql Server)
        public bool Administrator{ get; set; }

    }
}