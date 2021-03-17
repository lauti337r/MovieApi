using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class Movie
    {
        [Key] public Guid Id { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }

        public Person Director { get; set; }
        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }

        public Person Writer { get; set; }
        [ForeignKey("Writer")]
        public Guid WriterId { get; set; }
        public List<Person> Cast { get; set; }
    }
}
