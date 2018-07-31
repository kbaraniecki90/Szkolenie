using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szkolenie.Models
{
    public class Client
    {   public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public DateTime Data { get; set; }
        [Required]
        public string ProblemDetails { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int Phone { get; set; }



        public string FixDetails { get; set; }
        public DateTime FixData { get; set; }
        public bool IsFixed { get; set; }










   }
}