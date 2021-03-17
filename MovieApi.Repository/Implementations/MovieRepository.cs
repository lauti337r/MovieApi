using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        public Movie GetMovie(Guid id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie SaveMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            
            _context.Movies.Add(movie);

            if (_context.SaveChanges() > 0)
                return movie;
            return null;
        }

        public Movie UpdateMovie(Movie movie)
        {
            Movie movieToUpdate = this.GetMovie(movie.Id);

            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Country = movie.Country;
                movieToUpdate.DirectorId = movie.DirectorId;
                movieToUpdate.WriterId = movie.WriterId;
                movieToUpdate.Year = movie.Year;

                if (_context.SaveChanges() > 0)
                    return movieToUpdate;
                return null;
            }

            return null;
        }

        public bool DeleteMovie(Guid id)
        {
            Movie movieToDelete = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieToDelete == null)
                return false;

            _context.Movies.Remove((movieToDelete));

            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
