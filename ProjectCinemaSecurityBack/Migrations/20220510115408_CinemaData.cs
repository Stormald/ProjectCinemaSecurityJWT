using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCinemaSecurityBack.Migrations
{
    public partial class CinemaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilmModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoginModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "FilmModel",
                columns: new[] { "Id", "Name", "UrlImg" },
                values: new object[,]
                {
                    { 1L, "Les Animaux Fantastiques : Les secrets de Dumbledore", "https://fr.web.img6.acsta.net/c_310_420/pictures/22/03/16/15/20/0170262.jpg" },
                    { 2L, "Sonic 2", "https://www.cinemaspathegaumont.com/media/movie/9204523/poster/1649083946579/md/239/film_927013.jpg" },
                    { 3L, "Spider-Man 3", "https://fr.web.img3.acsta.net/medias/nmedia/18/35/62/65/18754165.jpg" },
                    { 4L, "Spider-Man : Across the Spider-Verse", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.numerama.com%2Fwp-content%2Fuploads%2F2021%2F12%2Fposter-across-the-spider-verse.jpg&imgrefurl=https%3A%2F%2Fwww.numerama.com%2Fpop-culture%2F761448-spider-man-across-the-spider-verse-va-montrer-davantage-de-spider-man-dautres-dimensions.html&tbnid=La1ZLNKMBXCifM&vet=12ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ..i&docid=60v0N3QCYEMKPM&w=715&h=1118&q=spider%20man%20across%20the%20spider-verse&hl=fr&client=firefox-b-d&ved=2ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ" }
                });

            migrationBuilder.InsertData(
                table: "LoginModel",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, "azerty", "thomas" },
                    { 2L, "qwerty", "lionel" },
                    { 3L, "admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmModel");

            migrationBuilder.DropTable(
                name: "LoginModel");
        }
    }
}
