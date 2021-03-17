using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Services.Interfaces;

namespace MovieApi.Controllers
{
    public class PersonController : BaseController
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Person>>> SearchPersons(string searchTerm)
        {
            List<Person> persons = _personService.SearchPersons(searchTerm);
            if (persons.Count == 0)
                return NotFound();
            return persons;
        }
        
        [HttpGet("country/{countryCode}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByCountry(string countryCode)
        {
            List<Person> personsByCountry = _personService.SearchByCountry(countryCode);

            if (personsByCountry.Count == 0)
                return NotFound();
            return personsByCountry;
        }


        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return _personService.GetAllPersons();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            person = _personService.UpdatePerson(person);

            if (person != null)
                return NoContent();
            return BadRequest();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            person = _personService.SavePerson(person);

            if (person != null)
                return CreatedAtAction("GetPerson", new { id = person.Id }, person);

            return BadRequest();
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            bool deletionSuccess = _personService.DeletePerson(id);

            if (deletionSuccess)
                return NoContent();
            return NotFound();
        }
    }
}
