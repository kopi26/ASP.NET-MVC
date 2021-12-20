using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalMoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalMoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRentals(RentalMovieDto rentalMovieDto)
        {
            //Noise of codes
           /* if (rentalMovieDto.MovieIds.Count == 0)
                return BadRequest("No MovieIds have been given");*/

            var customer = _context.Customers.Single(c => c.Id == rentalMovieDto.CustomerId);

           /* if (customer == null)
                return BadRequest("CustomerId is not valid");*/

            var movies = _context.Movies.Where(
                m => rentalMovieDto.MovieIds.Contains(m.Id)).ToList();
/*
            if (movies.Count != rentalMovieDto.MovieIds.Count)
                return BadRequest("One or More MovieIds are invalid");*/

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new RentalMovie
                {
                    Customer = customer,
                    Movie = movie,
                    DateRental = DateTime.Now
                };

                _context.RentalMovies.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
