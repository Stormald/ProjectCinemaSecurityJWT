using Microsoft.EntityFrameworkCore;
using ProjectCinemaSecurityBack.Models;

namespace ProjectCinemaSecurityBack.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<FilmModel> FilmModel { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>().HasData(
                new FilmModel { Id = 1, Name = "Les Animaux Fantastiques : Les secrets de Dumbledore", UrlImg = "https://fr.web.img6.acsta.net/c_310_420/pictures/22/03/16/15/20/0170262.jpg" },
                new FilmModel { Id = 2, Name = "Sonic 2", UrlImg = "https://www.cinemaspathegaumont.com/media/movie/9204523/poster/1649083946579/md/239/film_927013.jpg" },
                new FilmModel { Id = 3, Name = "Spider-Man 3", UrlImg= "https://fr.web.img3.acsta.net/medias/nmedia/18/35/62/65/18754165.jpg" },
                new FilmModel { Id = 4, Name = "Spider-Man : Across the Spider-Verse", UrlImg = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.numerama.com%2Fwp-content%2Fuploads%2F2021%2F12%2Fposter-across-the-spider-verse.jpg&imgrefurl=https%3A%2F%2Fwww.numerama.com%2Fpop-culture%2F761448-spider-man-across-the-spider-verse-va-montrer-davantage-de-spider-man-dautres-dimensions.html&tbnid=La1ZLNKMBXCifM&vet=12ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ..i&docid=60v0N3QCYEMKPM&w=715&h=1118&q=spider%20man%20across%20the%20spider-verse&hl=fr&client=firefox-b-d&ved=2ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ" }
                );

            modelBuilder.Entity<LoginModel>().HasData(
                new LoginModel { Id = 1, Username = "thomas", Password = "azerty" },
                new LoginModel { Id = 2, Username = "lionel", Password = "qwerty" },
                new LoginModel { Id = 3, Username = "admin", Password = "admin" }
                );

        }
    }
}
