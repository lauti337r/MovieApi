using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieApi.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
