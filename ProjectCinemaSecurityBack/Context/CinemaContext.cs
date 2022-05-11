using Microsoft.EntityFrameworkCore;
using ProjectCinemaSecurityBack.Models;

namespace ProjectCinemaSecurityBack.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<FilmModel> FilmModel { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }
        public DbSet<ReviewModel> ReviewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>().HasData(
                new FilmModel { Id = 1, Name = "Les Animaux Fantastiques : Les secrets de Dumbledore", UrlImg = "https://fr.web.img6.acsta.net/c_310_420/pictures/22/03/16/15/20/0170262.jpg" },
                new FilmModel { Id = 2, Name = "Sonic 2", UrlImg = "https://www.cinemaspathegaumont.com/media/movie/9204523/poster/1649083946579/md/239/film_927013.jpg" },
                new FilmModel { Id = 3, Name = "Spider-Man 3", UrlImg= "https://fr.web.img3.acsta.net/medias/nmedia/18/35/62/65/18754165.jpg" },
                new FilmModel { Id = 4, Name = "Spider-Man : Across the Spider-Verse", UrlImg = "https://media.senscritique.com/media/000020670575/source_big/spider_man_beyond_the_spider_verse.jpg" }
                );

            modelBuilder.Entity<LoginModel>().HasData(
                new LoginModel { Id = 1, Username = "thomas", Password = "azerty" },
                new LoginModel { Id = 2, Username = "lionel", Password = "qwerty" },
                new LoginModel { Id = 3, Username = "admin", Password = "admin" }
                );

            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel { Id = 1, Text = "Trop bien !", Score = 9, LoginModelId = 1, FilmModelId = 1 },
                new ReviewModel { Id = 2, Text = "Peut mieux faire...", Score = 6, LoginModelId = 2, FilmModelId = 1 },
                new ReviewModel { Id = 3, Text = "Je me suis endormis T-T", Score = 3, LoginModelId = 2, FilmModelId = 2 }
                );

        }
    }
}
