using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id=1, Name="Sherk"},
                new Movie {Id=2, Name="Wall-e"}
            };
        }





        //GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie=movie,
                Customer=customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = "+ id);
        }

        //movies
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        }
        */

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleasedDate(int year,int month)
        {
            return Content(year + "/" + month);
        }

    }
}
