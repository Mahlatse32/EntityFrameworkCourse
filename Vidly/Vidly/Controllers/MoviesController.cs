using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccessLayer;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _dbContext;

        public MoviesController()
        {
            _dbContext = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customer = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customer
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //if you wanna use it in the browser /Movies/Index?pageindex=1&sortby=ReleaseDate
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // /movies/release/2019/11
        [Route("movies/released/{year}/{month:regex(\\d{4}:range(1, 12)}")] //new ways of writing custom routes
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = _dbContext.Movies.Include(c => c.Genre).ToList();

            return movies;
        }

        public ActionResult MovieList()
        {
            return View(GetMovies());
        }

        public ActionResult MovieDetail(int id)
        {
            var movie = GetMovies().SingleOrDefault(x => x.Id == id);

            return View(movie);
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Movie";

            var viewModel = new MovieFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult EditMovie(int id)
        {
            ViewBag.Title = "Edit Movie";

            var movie = _dbContext.Movies.Where(x => x.Id == id).Include(x => x.Genre).FirstOrDefault();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _dbContext.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }


            _dbContext.SaveChanges();

            return RedirectToAction("MovieList", "Movies");
        }
    }
}