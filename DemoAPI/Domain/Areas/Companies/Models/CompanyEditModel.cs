using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.Companies.Models
{
    public class CompanyEditModel
    {
        public string CompanyName { get; set; }

        public string TelephoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
