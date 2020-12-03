﻿using Domain.Areas.Companies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.Companies.Managers
{
    public class CompaniesManager
    {
        public IEnumerable<CompanyDetailsModel> GetIndexModel(CompanySearchModel model)
        {
            throw new NotImplementedException();
        }

        public CompanyDetailsModel GetDetailsModel(long id)
        {
            if (false) //IF COMPANY NOT FOUND
            {
                return null;
            }
            else
            {
                return new CompanyDetailsModel
                {
                    CompanyName = "Example",
                    TelephoneNumber = "441234123456",
                    MobileNumber = "07519321456",
                    LastUpdated = DateTime.Now,
                    Postcode = "SW1A 1AA"
                };
            }
        }

        public void SaveEditModel(long id, CompanyEditModel model)
        {

        }

        public void SaveCreateModel(CompanyCreateModel model)
        {

        }

        public void Delete(long id)
        {

        }
    }
}
