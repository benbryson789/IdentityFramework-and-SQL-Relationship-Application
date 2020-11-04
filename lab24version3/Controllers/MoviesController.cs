using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab24version3.Data;
using lab24version3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab24version3.Controllers
{
    public class MoviesController : Controller
    {   //private field to assign an instance of httpcontext to. now we can use it. line 26 and 32
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        //added a constructor
        public MoviesController(IHttpContextAccessor httpContext,
            ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager)
        {
            _httpContext = httpContext;
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public Movies Movies { get; set; }


        public IActionResult Index()
        {
            var movies = _dbContext.Movies.ToList();
            var checkedoutMovies = _dbContext.CheckedOutMovies.ToDictionary(x => x.MovieID.Id);

            var moviesModel = new List<MoviesModel>();
            foreach (var movie in movies)
            {
                var movieModel = new MoviesModel
                {
                    Id = movie.Id,
                    Genre = movie.Genre,
                    Runtime = movie.Runtime,
                    Title = movie.Title,
                    IsAvailable = true
                };

                if (checkedoutMovies.ContainsKey(movie.Id))
                {
                    var checkoutMovie = checkedoutMovies[movie.Id];

                    movieModel.IsAvailable = false;
                    movieModel.DueDate = checkoutMovie.DueDate;
                }

                moviesModel.Add(movieModel);
            }

            return View(moviesModel);
        }

        public IActionResult Checkout(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        public async Task<IActionResult> Result(int id)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);

            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            var checkoutMovie = new CheckedOutMovies
            {
                UserID = user,
                MovieID = movie,
                DueDate = DateTime.Now.AddDays(7)
            };

            _dbContext.CheckedOutMovies.Add(checkoutMovie);
            await _dbContext.SaveChangesAsync();

            var movieModel = new MoviesModel
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Runtime = movie.Runtime,
                Title = movie.Title,
                IsAvailable = false,
                DueDate = checkoutMovie.DueDate
            };

            return View(movieModel);
        }

        public IActionResult CheckedOutMovies()
        {
            var checkedoutMovies = _dbContext.CheckedOutMovies.Include(x => x.MovieID).ToList();

            var moviesModel = new List<MoviesModel>();
            foreach (var checkedOutMovie in checkedoutMovies)
            {
                var movieModel = new MoviesModel
                {
                    Id = checkedOutMovie.MovieID.Id,
                    Genre = checkedOutMovie.MovieID.Genre,
                    Runtime = checkedOutMovie.MovieID.Runtime,
                    Title = checkedOutMovie.MovieID.Title
                };

                moviesModel.Add(movieModel);
            }

            return View(moviesModel);
        }

        public async Task<IActionResult> CheckBackIn(int id)
        {
            var checkoutMovie = _dbContext.CheckedOutMovies.FirstOrDefault(x => x.Id == id);
            _dbContext.CheckedOutMovies.Remove(checkoutMovie);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("CheckedOutMovies");
        }
    }
}