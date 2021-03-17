using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Models;

namespace MovieApi.Repository.Interfaces
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAllMovies();

        Movie GetMovie(Guid id);

        Movie SaveMovie(Movie movie);

        Movie UpdateMovie(Movie movie);

        bool DeleteMovie(Guid id);
    }
}
