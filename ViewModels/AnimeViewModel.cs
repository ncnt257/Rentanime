using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentanime.Models;

namespace Rentanime.ViewModels
{
    public class AnimeViewModel
    {
        public List<Anime> AnimeList { get; set; }

        public AnimeViewModel()
        {
            AnimeList = new List<Anime>();
            AnimeList.Add(new Anime(){Name="スラムダンク"});
            AnimeList.Add(new Anime(){Name="僕だけがいない街"});
        }
    }
}