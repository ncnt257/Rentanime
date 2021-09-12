using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using AutoMapper;
using Rentanime.Dtos;
using Rentanime.Models;

namespace Rentanime.Controllers.Api
{
    public class AnimesController : ApiController
    {
        private ApplicationDbContext _context;

        public AnimesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetAnimes()
        {
            return Ok(_context.Animes.ToList().Select(Mapper.Map<Anime,AnimeDto>));
        }

        public IHttpActionResult GetAnime(int id)
        {
            var animeInDb = _context.Animes.SingleOrDefault(a => a.Id == id);
            if (animeInDb == null)
                return NotFound();
            return Ok(Mapper.Map<Anime, AnimeDto>(animeInDb));
        }

        [HttpPost]
        public IHttpActionResult CreateAnime(AnimeDto animeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            animeDto.DateAdded = DateTime.Now;
            var anime = Mapper.Map<AnimeDto, Anime>(animeDto);
            _context.Animes.Add(anime);
            _context.SaveChanges();
            animeDto.Id = anime.Id;
            return Created(new Uri(Request.RequestUri + "/" + animeDto.Id), animeDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateAnime(int id, AnimeDto animeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var animeInDb = _context.Animes.SingleOrDefault(a => a.Id == id);
            if (animeInDb == null)
                return NotFound();
            animeDto.DateAdded = animeInDb.DateAdded;
            Mapper.Map(animeDto, animeInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAnime(int id)
        {
            var animeInDb = _context.Animes.SingleOrDefault(a => a.Id == id);
            if (animeInDb == null)
                return NotFound();
            _context.Animes.Remove(animeInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
