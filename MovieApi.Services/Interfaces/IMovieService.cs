using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Models;

namespace MovieApi.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();

        List<Movie> GetMoviesByYear(string year);

        List<Movie> GetMoviesByCountry(string country);

        List<Movie> SearchMoviesByTitle(string searchTerm);

        Movie GetMovie(Guid id);

        Movie SaveMovie(Movie movie);

        Movie UpdateMovie(Movie movie);

        bool DeleteMovie(Guid id);
    }
}
