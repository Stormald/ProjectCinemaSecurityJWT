// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCinemaSecurityBack.Context;

#nullable disable

namespace ProjectCinemaSecurityBack.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20220510115408_CinemaData")]
    partial class CinemaData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectCinemaSecurityBack.Models.FilmModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("UrlImg")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FilmModel");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Les Animaux Fantastiques : Les secrets de Dumbledore",
                            UrlImg = "https://fr.web.img6.acsta.net/c_310_420/pictures/22/03/16/15/20/0170262.jpg"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Sonic 2",
                            UrlImg = "https://www.cinemaspathegaumont.com/media/movie/9204523/poster/1649083946579/md/239/film_927013.jpg"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Spider-Man 3",
                            UrlImg = "https://fr.web.img3.acsta.net/medias/nmedia/18/35/62/65/18754165.jpg"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Spider-Man : Across the Spider-Verse",
                            UrlImg = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.numerama.com%2Fwp-content%2Fuploads%2F2021%2F12%2Fposter-across-the-spider-verse.jpg&imgrefurl=https%3A%2F%2Fwww.numerama.com%2Fpop-culture%2F761448-spider-man-across-the-spider-verse-va-montrer-davantage-de-spider-man-dautres-dimensions.html&tbnid=La1ZLNKMBXCifM&vet=12ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ..i&docid=60v0N3QCYEMKPM&w=715&h=1118&q=spider%20man%20across%20the%20spider-verse&hl=fr&client=firefox-b-d&ved=2ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ"
                        });
                });

            modelBuilder.Entity("ProjectCinemaSecurityBack.Models.LoginModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LoginModel");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Password = "azerty",
                            Username = "thomas"
                        },
                        new
                        {
                            Id = 2L,
                            Password = "qwerty",
                            Username = "lionel"
                        },
                        new
                        {
                            Id = 3L,
                            Password = "admin",
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
