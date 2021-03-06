﻿using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerWithAuthMVC_app.Models.ViewModel;
using System.Data.Entity;
using System.Net;


namespace MovieCustomerWithAuthMVC_app.Controllers
{
    public class MoviesController : Controller
    {
        //// GET: Movies
        //private ApplicationDbContext _context;
        //// GET: Movie
        //public MoviesController()
        //{
        //    _context = new ApplicationDbContext();
        //}
        //public ActionResult Index()
        //{
        //    var mov = _context.Movies.Include(c => c.Genre).ToList();
        //    return View(mov);
        //}
        //public ActionResult Details(int id)
        //{
        //    var singleMovie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        //    if (singleMovie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(singleMovie);
        //}
        //[HttpGet]
        //public ActionResult New()
        //{
        //    var genre = _context.Genres.ToList();
        //    var viewModel = new NewMovieViewModel
        //    {
        //        Genres = genre
        //    };
        //    return View(viewModel);
        //}
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model binding
        //{
        //    _context.Movies.Add(movie);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var movieTbl = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        //    if (movieTbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Genres = new SelectList(_context.Genres, "Id", "GenreName", movieTbl.GenreId);
        //    return View("New",movieTbl);  //changes here
        //}
        /////New Code
        //[HttpPost]
        //public ActionResult Save(Movie movie)
        //{
        //    if (movie.Id == 0)
        //        _context.Movies.Add(movie);
        //    else
        //    {
        //        var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
        //        movieInDb.MovieName = movie.MovieName;
        //        movieInDb.Genre = movie.Genre;
        //    }
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        ////
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    };
        //    var movieTbl = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        //    if (movieTbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movieTbl);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var movieTbl = _context.Movies.Find(id);
        //    _context.Movies.Remove(movieTbl);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}





        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var mov = _context.Movies.Include(c => c.Genre).ToList();
            return View(mov);
        }
        public ActionResult Details(int id)
        {
            var singleMovie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
            {
                return HttpNotFound();
            }
            return View(singleMovie);
        }
        [HttpGet]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genre
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model binding
        //{
        //    _context.Movies.Add(movie);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0) _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.GenreId = movie.GenreId;


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var updateMov = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (updateMov == null)
            {
                return HttpNotFound();
            }
            var vm = new NewMovieViewModel
            {
                Movie = updateMov,
                Genres = _context.Genres.ToList()
            };
            return View("New", vm);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieTbl = _context.Movies.Find(id);
            _context.Movies.Remove(movieTbl);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }









    }
}




