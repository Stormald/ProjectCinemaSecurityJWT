using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Repositories;

namespace ProjectCinemaSecurityBack.Services
{
    public class FilmService
    {
        private FilmRepository filmRepository;
        public FilmService(FilmRepository repo)
        {
            filmRepository = repo;
        }

        public FilmModel AddFilm(FilmModel film)
        {
            return this.filmRepository.AddFilm(film);
        }

        public void DeleteFilm(int id)
        {
            this.filmRepository.DeleteFilm(id);
        }

        public FilmModel GetFilmById(int id)
        {
            return this.filmRepository.GetFilmById(id);
        }

        public IEnumerable<FilmModel> GetFilms()
        {
            return this.filmRepository.GetFilms();
        }

        public FilmModel UpdateFilm(FilmModel film)
        {
            return this.filmRepository.UpdateFilm(film);
        }
    }
}
