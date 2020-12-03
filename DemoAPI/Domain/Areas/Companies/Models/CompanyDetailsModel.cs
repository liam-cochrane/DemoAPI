using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.Companies.Models
{
    public class CompanyDetailsModel
    {
        public long CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string TelephoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Postcode { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
