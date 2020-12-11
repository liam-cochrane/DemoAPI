using Domain.Areas.People.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Mock;
using Data.Mock.Objects;
using System.Linq;

namespace Domain.Areas.People.Managers
{
    public class PeopleManager
    {
        private readonly DataContext dc;

        public PeopleManager()
        {
            dc = new DataContext();
        }

        public IEnumerable<PersonDetailsModel> GetIndexModel(PersonSearchModel search)
        {
            var items = dc.People.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(" ");

                    foreach (string word in words)
                    {
                        items = items.Where(X => X.Forename.ToUpper().Contains(word) ||
                            X.Surname.ToUpper().Contains(word) ||
                            X.MobileNumber.ToUpper().Contains(word) ||
                            X.TelephoneNumber.ToUpper().Contains(word) ||
                            X.Email.ToUpper().Contains(word) ||
                            X.JobTitle.ToUpper().Contains(word));
                    }
                }
            }

            var response = new List<PersonDetailsModel>();

            foreach (var item in items)
            {
                response.Add(new PersonDetailsModel
                {
                    PersonId = item.Id,
                    Forename = item.Forename,
                    Surname = item.Surname,
                    TelephoneNumber = item.TelephoneNumber,
                    MobileNumber = item.MobileNumber,
                    Email = item.Email,
                    JobTitle = item.JobTitle
                });
            }

            return response;
        }

        public PersonDetailsModel GetDetailsModel(long id)
        {
            var item = dc.People.Find(X => X.Id == id);
            if (item == null)
            {
                return null;
            }
            else
            {
                return new PersonDetailsModel
                {
                    PersonId = item.Id,
                    Forename = item.Forename,
                    Surname = item.Surname,
                    TelephoneNumber = item.TelephoneNumber,
                    MobileNumber = item.MobileNumber,
                    Email = item.Email,
                    JobTitle = item.JobTitle,
                };
            }
        }

        public long SaveCreateModel(PersonCreateModel model)
        {
            var item = new Person
            {
                CompanyId = model.CompanyId,
                Forename = model.Forename,
                Surname = model.Surname,
                Email = model.Email,
                JobTitle = model.JobTitle,
                MobileNumber = model.MobileNumber,
                TelephoneNumber = model.TelephoneNumber
            };

            dc.People.Add(item);

            //dc.Save();

            long id = 123456;

            return id;
        }

        public void SaveEditModel(long id, PersonEditModel model)
        {
            var item = dc.People.Find(X => X.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                item.CompanyId = model.CompanyId;
                item.Forename = model.Forename;
                item.Surname = model.Surname;
                item.Email = model.Email;
                item.JobTitle = model.JobTitle;
                item.MobileNumber = model.MobileNumber;
                item.TelephoneNumber = model.TelephoneNumber;

                //dc.Save();
            }
        }

        public void Delete(long id)
        {
            var item = dc.People.Find(X => X.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                dc.People.Remove(item);

                //dc.Save();
            }
        }
    }
}
