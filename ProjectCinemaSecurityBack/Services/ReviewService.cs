using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Repositories;

namespace ProjectCinemaSecurityBack.Services
{
    public class ReviewService
    {
        private ReviewRepository reviewRepository;
        public ReviewService(ReviewRepository repo)
        {
            reviewRepository = repo;
        }

        public ReviewModel AddReview(ReviewModel review)
        {
            return this.reviewRepository.AddReview(review);
        }

        public void DeleteReview(int id)
        {
            this.reviewRepository.DeleteReview(id);
        }

        public ReviewModel GetReviewById(int id)
        {
            return this.reviewRepository.GetReviewById(id);
        }

        public IEnumerable<ReviewModel> GetReviewsByIdFilm(int idFilm)
        {
            return this.reviewRepository.GetReviewsByIdFilm(idFilm);
        }

        public IEnumerable<ReviewModel> GetReviews()
        {
            return this.reviewRepository.GetReviews();
        }

        public ReviewModel UpdateReview(ReviewModel review)
        {
            return this.reviewRepository.UpdateReview(review);
        }
    }
}
