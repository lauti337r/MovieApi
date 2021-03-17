using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Models;

namespace MovieApi.Repository.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAllPersons();

        Person GetPerson(Guid id);

        Person SavePerson(Person person);

        Person UpdatePerson(Person person);

        bool DeletePerson(Guid id);
    }
}
