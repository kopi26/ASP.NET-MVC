using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m => m.GenreType)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));

            var movieDtos = movieQuery
                .ToList().
                Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id) , movieDto);
        }

        // PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

           /* movieInDb.Name = movieDto.Name;
            movieInDb.ReleasedDate = movieDto.ReleasedDate;
            movieInDb.GenreTypeId = movieDto.GenreTypeId;
            movieInDb.NoInStocks = movieDto.NoInStocks;*/

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
