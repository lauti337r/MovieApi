using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Services.Interfaces;

namespace MovieApi.Controllers
{
    public class MoviesController : BaseController
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet("searchByTitle/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Movie>>> SearchByTitle(string searchTerm)
        {
            List<Movie> movies = _movieService.SearchMoviesByTitle(searchTerm);

            if (movies.Count == 0)
                return NotFound();
            return movies;
        }

        [HttpGet("country/{countryCode}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByCountry(string countryCode)
        {
            List<Movie> moviesByCountry = _movieService.GetMoviesByCountry(countryCode);

            if (moviesByCountry.Count == 0)
                return NotFound();
            return moviesByCountry;
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByYear(string year)
        {
            List<Movie> moviesByYear = _movieService.GetMoviesByYear(year);

            if (moviesByYear.Count == 0)
                return NotFound();
            return moviesByYear;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return _movieService.GetAllMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = _movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            movie = _movieService.UpdateMovie(movie);

            if (movie != null)
                return NoContent();
            return BadRequest();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            movie = _movieService.SaveMovie(movie);

            if(movie != null)
                return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);

            return BadRequest();

        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            bool deletionSuccess = _movieService.DeleteMovie(id);

            if (deletionSuccess)
                return NoContent();
            return NotFound();
        }
    }
}
