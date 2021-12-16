using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModels
            {
                GenreTypes = genreTypes,
                Movie = new Movie(),
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.NoInStocks = movie.NoInStocks;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModels
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreType).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        /*
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
        
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        }
        

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleasedDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
        */
    }
}
