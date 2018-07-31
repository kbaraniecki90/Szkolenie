using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szkolenie.Models
{
    public class Client
    {   public int Id { get; set; }
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Login { get; set; }
        public DateTime? Data { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść*")]
        public string ProblemDetails { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        public int Phone { get; set; }


        [DataType(DataType.MultilineText)]
        public string FixDetails { get; set; }

        public DateTime? FixData { get; set; }
        public bool IsFixed { get; set; }










   }
}