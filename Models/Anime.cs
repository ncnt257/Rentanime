using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentanime.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}