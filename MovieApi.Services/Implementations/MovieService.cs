using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Models;
using MovieApi.Repository;
using MovieApi.Repository.Interfaces;
using MovieApi.Services.Interfaces;

namespace MovieApi.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies().ToList();
        }

        public List<Movie> GetMoviesByYear(string year)
        {
            return _movieRepository.GetAllMovies().Where(m => m.Year == year).ToList();
        }

        public List<Movie> GetMoviesByCountry(string country)
        {
            return _movieRepository.GetAllMovies().Where(m => m.Country == country).ToList();
        }

        public List<Movie> SearchMoviesByTitle(string searchTerm)
        {
            return _movieRepository.GetAllMovies().Where(m => m.Title.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        public Movie GetMovie(Guid id)
        {
            return _movieRepository.GetMovie(id);
        }

        public Movie SaveMovie(Movie movie)
        {
            return _movieRepository.SaveMovie(movie);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }

        public bool DeleteMovie(Guid id)
        {
            return _movieRepository.DeleteMovie(id);
        }
    }
}
