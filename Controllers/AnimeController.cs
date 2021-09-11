using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentanime.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using Rentanime.ViewModels;

namespace Rentanime.Controllers
{
    public class AnimeController : Controller
    {
        private ApplicationDbContext _context;
        public AnimeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        //public ActionResult Random()
        //{
        //    var anime = new Anime()
        //    {
        //        Name = "僕だけがいない街"
        //    };
        //    return View(anime);
        //}

        public ActionResult Index()
        {
            var animes = _context.Animes.Include(a=>a.Genre).ToList();
            return View(animes);
        }
        
        public ActionResult Details(int id)
        {
            var anime = _context.Animes.Include(a=>a.Genre).SingleOrDefault(a => a.Id == id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Anime";
            var viewModel = new AnimeFormViewModel()
            {
                Anime = _context.Animes.Single(a => a.Id == id),
                Genres = _context.Genres.ToList()
            };
            return View("AnimeForm",viewModel);
        }
        public ActionResult Create()
        {
            ViewBag.Title = "Create Anime";

            var viewModel = new AnimeFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("AnimeForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Anime anime)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = anime.Id == 0 ? "Create Anime" : "Edit Anime";
                var viewModel = new AnimeFormViewModel()
                {
                    Anime = anime,
                    Genres = _context.Genres.ToList()
                };
                return View("AnimeForm", viewModel);
            }
            if (anime.Id == 0)
            {
                anime.DateAdded = DateTime.Now;
                _context.Animes.Add(anime);
            }
            else
            {
                var animeInDb = _context.Animes.Single(a => a.Id == anime.Id);
                animeInDb.Name = anime.Name;
                animeInDb.ReleasedDate = anime.ReleasedDate;
                animeInDb.GenreId = anime.GenreId;
                animeInDb.NumberInStock = anime.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
