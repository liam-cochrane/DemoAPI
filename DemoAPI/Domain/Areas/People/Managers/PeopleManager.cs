﻿using Domain.Areas.People.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Areas.People.Managers
{
    public class PeopleManager
    {
        public IEnumerable<PersonDetailsModel> GetIndexModel(PersonSearchModel model)
        {
            throw new NotImplementedException();
        }

        public PersonDetailsModel GetDetailsModel(long id)
        {
            if (false) //IF COMPANY NOT FOUND
            {
                return null;
            }
            else
            {
                return new PersonDetailsModel
                {
                    Forename = "Example",
                    Surname = "Person",
                    TelephoneNumber = "441234123456",
                    MobileNumber = "07519321456",
                    Email = "example@email.com",
                    JobTitle = "CEO"
                };
            }
        }

        public void SaveEditModel(long id, PersonEditModel model)
        {

        }

        public void SaveCreateModel(PersonCreateModel model)
        {

        }

        public void Delete(long id)
        {

        }
    }
}