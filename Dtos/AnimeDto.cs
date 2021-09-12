using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Rentanime.Models;

namespace Rentanime.Dtos
{
    public class AnimeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }


    }
}