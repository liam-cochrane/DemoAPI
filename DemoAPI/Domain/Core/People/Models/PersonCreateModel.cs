using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Areas.People.Models
{
    public class PersonCreateModel
    {
        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public long CompanyId { get; set; }

        [Phone]
        public string TelephoneNumber { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string JobTitle { get; set; }
    }
}
