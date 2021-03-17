using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic.CompilerServices;
using MovieApi.Models;
using MovieApi.Utils;

namespace MovieApi.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            LoadData();
        }

        private void LoadData()
        {
            Person jjCampanella = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Juan Jose Campanella" };
            Persons.Add(jjCampanella);

            Person rDarin = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Ricardo Darin" };
            Persons.Add(rDarin);

            Person gFrancella = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Guillermo Francella" };
            Persons.Add(gFrancella);

            Person sVillamil = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Soledad Villamil" };
            Persons.Add(sVillamil);

            Movie secretInTheirEyes = new Movie()
            {
                Country = "AR",
                Cast = new List<Person>() {rDarin, gFrancella, sVillamil},
                Title = "The secret in their eyes",
                Director = jjCampanella, Id = Guid.NewGuid(), Writer = jjCampanella, Year = "2009",
                Plot =
                    "A retired legal counselor writes a novel hoping to find closure for one of his past unresolved homicide cases and for his unreciprocated love with his superior - both of which still haunt him decades later.",
            };

            Movies.Add(secretInTheirEyes);

            Person fBielinsky = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Fabian Bielinsky" };
            Persons.Add(fBielinsky);

            Person gPauls = new Person() { Id = Guid.NewGuid(), Country = "AR", Name = "Gaston Pauls" };
            Persons.Add(gPauls);

            Movie nineQueens = new Movie()
            {
                Country = "AR",
                Cast = new List<Person>() {rDarin, gPauls},
                Title = "Nine Queens",
                Director = fBielinsky,
                Id = Guid.NewGuid(),
                Writer = fBielinsky,
                Year = "2000",
                Plot =
                    "Two con artists try to swindle a stamp collector by selling him a sheet of counterfeit rare stamps (the \"nine queens\").",
            };

            Movies.Add(nineQueens);

            Person sergioLeone = new Person() { Id = Guid.NewGuid(), Country = "IT", Name = "Sergio Leone" };
            Persons.Add(sergioLeone);

            Person clintEastwood = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "Clint Eastwood" };
            Persons.Add(clintEastwood);

            Person leeVanCleef = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "Lee Van Cleef" };
            Persons.Add(leeVanCleef);

            Movie forAFewDollarsMore = new Movie()
            {
                Country = "IT",
                Cast = new List<Person>() {clintEastwood, leeVanCleef},
                Title = "For a Few Dollars More",
                Director = sergioLeone,
                Id = Guid.NewGuid(),
                Writer = sergioLeone,
                Year = "1965",
                Plot = "Two bounty hunters with the same intentions team up to track down a Western outlaw.",
            };

            Movies.Add(forAFewDollarsMore);

            Person quentinTarantino = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "Quentin Tarantino" };
            Persons.Add(quentinTarantino);

            Person samulLJackson = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "Samuel L. Jackson" };
            Persons.Add(samulLJackson);
            
            Person johnTravolta = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "John Travolta" };
            Persons.Add(johnTravolta);
            
            Person umaThurman = new Person() { Id = Guid.NewGuid(), Country = "US", Name = "Uma Thurman" };
            Persons.Add(umaThurman);

            Movie pulpFiction = new Movie()
            {
                Country = "US",
                Cast = new List<Person>() { samulLJackson, johnTravolta, umaThurman },
                Title = "Pulp Fiction",
                Director = quentinTarantino,
                Id = Guid.NewGuid(),
                Writer = quentinTarantino,
                Year = "1994",
                Plot = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
            };

            Movies.Add(pulpFiction);

            string defaultPassword = "pw1234!";

            string hashedPassword = StringUtils.Hash(defaultPassword);

            User user = new User()
            {
                Country = "AR",
                FullName = "Lautaro Romeo",
                Password = hashedPassword,
                Id = Guid.NewGuid(),
                Username = "lromeo"
            };

            Users.Add(user);

            user = new User()
            {
                Country = "US", 
                FullName = "Marc Wojtowicz", 
                Id = Guid.NewGuid(), 
                Password = defaultPassword,
                Username = "mwojtowicz"
            };

            Users.Add(user);

            SaveChanges();
        }
    }
}
