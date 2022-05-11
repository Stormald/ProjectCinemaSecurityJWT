using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Services;

namespace ProjectCinemaSecurityBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly ReviewService service;
        public ReviewController(ReviewService Service)
        {
            service = Service;
        }

        [HttpGet("{id}")]
        public ReviewModel GetReviewById(int id)
        {
            return this.service.GetReviewById(id);
        }

        [HttpGet("Film/{idFilm}")]
        public IEnumerable<ReviewModel> GetReviewsByIdFilm(int idFilm)
        {
            return this.service.GetReviewsByIdFilm(idFilm);
        }

        [HttpGet]
        public IEnumerable<ReviewModel> GetReviews()
        {
            return this.service.GetReviews();
        }

        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public ReviewModel AddReview(ReviewModel review)
        {
            return this.service.AddReview(review);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public ReviewModel UpdateReview(ReviewModel review)
        {
            return this.service.UpdateReview(review);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                this.service.DeleteReview(id);
                return Ok("The listPerso got deleted.");
            }
            catch (Exception e)
            {
                return BadRequest("Invalide request" + e.Message);
            }

        }
    }
}
