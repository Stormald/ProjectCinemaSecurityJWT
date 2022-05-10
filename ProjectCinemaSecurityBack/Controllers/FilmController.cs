using Microsoft.AspNetCore.Mvc;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Services;

namespace ProjectCinemaSecurityBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly FilmService service;
        public FilmController(FilmService Service)
        {
            service = Service;
        }

        [HttpGet("{id}")]
        public FilmModel GetFilmById(int id)
        {
            return this.service.GetFilmById(id);
        }

        [HttpGet]
        public IEnumerable<FilmModel> GetFilms()
        {
            return this.service.GetFilms();
        }

        [HttpPost]
        public FilmModel AddFilm(FilmModel film)
        {
            return this.service.AddFilm(film);
        }

        [HttpPut]
        public FilmModel UpdateFilm(FilmModel film)
        {
            return this.service.UpdateFilm(film);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            try
            {
                this.service.DeleteFilm(id);
                return Ok("The listPerso got deleted.");
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
