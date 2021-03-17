using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MovieContext _context;

        public PersonRepository(MovieContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetAllPersons()
        {
            return _context.Persons;
        }

        public Person GetPerson(Guid id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public Person SavePerson(Person person)
        {
            person.Id = Guid.NewGuid();

            _context.Persons.Add(person);

            if (_context.SaveChanges() > 0)
                return person;
            return null;
        }

        public Person UpdatePerson(Person person)
        {
            Person personToUpdate = this.GetPerson(person.Id);

            if (personToUpdate != null)
            {
                personToUpdate.Country = person.Country;
                personToUpdate.Name = person.Name;

                if (_context.SaveChanges() > 0)
                    return personToUpdate;
                return null;
            }

            return null;
        }

        public bool DeletePerson(Guid id)
        {
            Person personToDelete = _context.Persons.FirstOrDefault(p => p.Id == id);

            if (personToDelete == null)
                return false;

            _context.Persons.Remove((personToDelete));

            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
