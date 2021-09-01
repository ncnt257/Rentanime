using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentanime.Models;

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
        public ActionResult Random()
        {
            var anime = new Anime()
            {
                Name = "僕だけがいない街"
            };
            return View(anime);
        }

        public ActionResult Index()
        {
            var Animes = _context.Animes.ToList();
            return View(Animes);
        }
    }
}