using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;

namespace ProjectCinemaSecurityBack.Repositories
{
    public class FilmRepository
    {

        private readonly CinemaContext context;
        public FilmRepository(CinemaContext Context)
        {
            context = Context;
        }

        public FilmModel AddFilm(FilmModel film)
        {
            this.context.FilmModel.Add(film);
            this.context.SaveChanges();
            return film;
        }

        public void DeleteFilm(int id)
        {
            this.context.FilmModel.Remove(this.context.FilmModel.FirstOrDefault(a => a.Id == id));
            this.context.SaveChanges();
        }

        public FilmModel GetFilmById(int id)
        {
            FilmModel film = this.context.FilmModel.FirstOrDefault(a => a.Id == id);

            return film;
        }

        public IEnumerable<FilmModel> GetFilms()
        {
            return this.context.FilmModel.ToList();
        }

        public FilmModel UpdateFilm(FilmModel film)
        {
            this.context.FilmModel.Update(film);
            this.context.SaveChanges();
            return film;
        }
    }
}
