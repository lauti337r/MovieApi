using System;
using System.Collections.Generic;
using System.Text;
using MovieApi.Models;

namespace MovieApi.Services.Interfaces
{
    public interface IPersonService
    {
        List<Person> SearchPersons(string searchTerm);

        List<Person> SearchByCountry(string countryCode);

        List<Person> GetAllPersons();

        Person GetPerson(Guid id);

        Person UpdatePerson(Person person);

        Person SavePerson(Person person);

        bool DeletePerson(Guid id);
    }
}
