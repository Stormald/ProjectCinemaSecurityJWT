using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinemaSecurityBack.Models
{
    public class ReviewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Text { get; set; }
        public int? Score { get; set; }

        [ForeignKey("LoginModel")]
        public long LoginModelId { get; set; }
        public LoginModel? LoginModel { get; set; }

        [ForeignKey("FilmModel")]
        public long FilmModelId { get; set; }
        public FilmModel? FilmModel { get; set; }

    }
}
