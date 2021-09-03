using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentanime.Models;

namespace Rentanime.ViewModels
{
    public class AnimeFormViewModel
    {
        public Anime Anime { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}