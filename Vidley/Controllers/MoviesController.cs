using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbcontext;
        public MoviesController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Movies = _dbcontext.Movies.Include(s=>s.Genre).ToList(); 


            return View(Movies);
        }
        public ActionResult Details(int id)
        {
            var Movie = _dbcontext.Movies.Include(s=>s.Genre).SingleOrDefault(c => c.Id == id);
            if (Movie == null)
                return HttpNotFound();
            
            return View(Movie);
        }
        public ActionResult New()
        {
            var genre = _dbcontext.Genre.ToList();
            var viewModel = new MovieViewModel
            {
                genre = genre
            };
            return View(viewModel);  
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _dbcontext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieViewModel
            {
                Movie = movie,
                genre = _dbcontext.Genre.ToList()
            };
            return View("New",viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now.Date;
                _dbcontext.Movies.Add(movie);
            }
            else
            {
                var mov = _dbcontext.Movies.SingleOrDefault(c => c.Id == movie.Id);
                mov.Name = movie.Name;
                mov.RealeaseDate = movie.RealeaseDate;
                mov.NumberInStock = movie.NumberInStock;
                mov.GenreId = movie.GenreId;
                mov.DateAdded = DateTime.Now.Date;      
            }
            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Delete(int id)
        {
            var mov = _dbcontext.Movies.SingleOrDefault(c => c.Id == id);
            if (mov == null)
                return HttpNotFound();
            var viewModel = new MovieViewModel
            {
                Movie = mov,
                genre=_dbcontext.Genre.ToList()

            };
            return View(viewModel);
        }
        public ActionResult Remove(int id)
        {
            var movie = _dbcontext.Movies.Single(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            _dbcontext.Movies.Remove(movie);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}