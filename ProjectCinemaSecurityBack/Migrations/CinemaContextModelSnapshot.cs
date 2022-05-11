﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCinemaSecurityBack.Context;

#nullable disable

namespace ProjectCinemaSecurityBack.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            UrlImg = "https://media.senscritique.com/media/000020670575/source_big/spider_man_beyond_the_spider_verse.jpg"
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

            modelBuilder.Entity("ProjectCinemaSecurityBack.Models.ReviewModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("FilmModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("LoginModelId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FilmModelId");

                    b.HasIndex("LoginModelId");

                    b.ToTable("ReviewModel");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FilmModelId = 1L,
                            LoginModelId = 1L,
                            Score = 9,
                            Text = "Trop bien !"
                        },
                        new
                        {
                            Id = 2L,
                            FilmModelId = 1L,
                            LoginModelId = 2L,
                            Score = 6,
                            Text = "Peut mieux faire..."
                        },
                        new
                        {
                            Id = 3L,
                            FilmModelId = 2L,
                            LoginModelId = 2L,
                            Score = 3,
                            Text = "Je me suis endormis T-T"
                        });
                });

            modelBuilder.Entity("ProjectCinemaSecurityBack.Models.ReviewModel", b =>
                {
                    b.HasOne("ProjectCinemaSecurityBack.Models.FilmModel", "FilmModel")
                        .WithMany()
                        .HasForeignKey("FilmModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectCinemaSecurityBack.Models.LoginModel", "LoginModel")
                        .WithMany()
                        .HasForeignKey("LoginModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmModel");

                    b.Navigation("LoginModel");
                });
#pragma warning restore 612, 618
        }
    }
}
