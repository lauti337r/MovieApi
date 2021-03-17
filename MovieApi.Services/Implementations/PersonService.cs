using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;
using MovieApi.Services.Interfaces;

namespace MovieApi.Services.Implementations
{
    public class PersonService: IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<Person> SearchPersons(string searchTerm)
        {
            return _personRepository.GetAllPersons().Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        public List<Person> SearchByCountry(string countryCode)
        {
            return _personRepository.GetAllPersons().Where(p => p.Country == countryCode).ToList();
        }

        public List<Person> GetAllPersons()
        {
            return _personRepository.GetAllPersons().ToList();
        }

        public Person GetPerson(Guid id)
        {
            return _personRepository.GetPerson(id);
        }

        public Person UpdatePerson(Person person)
        {
            return _personRepository.UpdatePerson(person);
        }

        public Person SavePerson(Person person)
        {
            return _personRepository.SavePerson(person);
        }

        public bool DeletePerson(Guid id)
        {
            return _personRepository.DeletePerson(id);
        }
    }
}
