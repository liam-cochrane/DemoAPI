using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.People.Models
{
    public class PersonEditModel
    {
        public string Forename { get; set; }

        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }
    }
}
