using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentanime.Models;
using Rentanime.ViewModels;

namespace Rentanime.Controllers
{
    public class AnimeController : Controller
    {
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
            var list = new AnimeViewModel();
            return View(list);
        }
    }
}