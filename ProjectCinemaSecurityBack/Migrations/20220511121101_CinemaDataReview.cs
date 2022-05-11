using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCinemaSecurityBack.Migrations
{
    public partial class CinemaDataReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<int>(type: "int", nullable: true),
                    LoginModelId = table.Column<long>(type: "bigint", nullable: false),
                    FilmModelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewModel_FilmModel_FilmModelId",
                        column: x => x.FilmModelId,
                        principalTable: "FilmModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewModel_LoginModel_LoginModelId",
                        column: x => x.LoginModelId,
                        principalTable: "LoginModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FilmModel",
                keyColumn: "Id",
                keyValue: 4L,
                column: "UrlImg",
                value: "https://media.senscritique.com/media/000020670575/source_big/spider_man_beyond_the_spider_verse.jpg");

            migrationBuilder.InsertData(
                table: "ReviewModel",
                columns: new[] { "Id", "FilmModelId", "LoginModelId", "Score", "Text" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, 9, "Trop bien !" },
                    { 2L, 1L, 2L, 6, "Peut mieux faire..." },
                    { 3L, 2L, 2L, 3, "Je me suis endormis T-T" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewModel_FilmModelId",
                table: "ReviewModel",
                column: "FilmModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewModel_LoginModelId",
                table: "ReviewModel",
                column: "LoginModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewModel");

            migrationBuilder.UpdateData(
                table: "FilmModel",
                keyColumn: "Id",
                keyValue: 4L,
                column: "UrlImg",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.numerama.com%2Fwp-content%2Fuploads%2F2021%2F12%2Fposter-across-the-spider-verse.jpg&imgrefurl=https%3A%2F%2Fwww.numerama.com%2Fpop-culture%2F761448-spider-man-across-the-spider-verse-va-montrer-davantage-de-spider-man-dautres-dimensions.html&tbnid=La1ZLNKMBXCifM&vet=12ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ..i&docid=60v0N3QCYEMKPM&w=715&h=1118&q=spider%20man%20across%20the%20spider-verse&hl=fr&client=firefox-b-d&ved=2ahUKEwiRlYe17tT3AhX8RPEDHWiKDYwQMygBegUIARC7AQ");
        }
    }
}
