using Data.Mock;
using Domain.Core.Companies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Companies.Managers
{
    public class CompaniesManager
    {
        private readonly DataContext dc;

        public CompaniesManager()
        {
            dc = new DataContext();
        }

        public IEnumerable<CompanyDetailsModel> GetIndexModel(CompanySearchModel search)
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
                    CompanyId = id,
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
