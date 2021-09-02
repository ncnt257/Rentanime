using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentanime.Models;
using System.Data.Entity;

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
            var animes = _context.Animes.ToList();
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
    }
}