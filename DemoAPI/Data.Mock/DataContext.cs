using Data.Mock.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mock
{
    public class DataContext
    {
        private List<Person> _people;
        private List<Company> _companies;
        private List<History> _histories;

        public List<Person> People
        {
            get
            {
                if (_people == null)
                {
                    _people = new List<Person>();
                    _people.Add(new Person
                    {
                        Id = 123456,
                        Forename = "David",
                        Surname = "Exampleson",
                        Email = "david@example.com",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678",
                        JobTitle = "Shopfloor Assistant"
                    });
                    _people.Add(new Person
                    {
                        Id = 999324,
                        Forename = "Barry",
                        Surname = "Banana",
                        Email = "barry@example.com",
                        TelephoneNumber = "01449123825",
                        MobileNumber = "07519123724",
                        JobTitle = "Bishop"
                    });
                    _people.Add(new Person
                    {
                        Id = 666345,
                        Forename = "Amanda",
                        Surname = "Apricot",
                        Email = "amanda@example.com",
                        TelephoneNumber = "013457432",
                        MobileNumber = "07519123635",
                        JobTitle = "Clerk"
                    });
                }

                return _people;
            }

        }

        public List<Company> Companies
        {
            get
            {
                if (_companies == null)
                {
                    _companies = new List<Company>();
                    _companies.Add(new Company
                    {
                        Id = 123456,
                        CompanyName = "David",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678"
                    });
                }

                return _companies;
            }

        }
    }
}
