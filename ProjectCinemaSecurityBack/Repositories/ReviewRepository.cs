using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;

namespace ProjectCinemaSecurityBack.Repositories
{
    public class ReviewRepository
    {

        private readonly CinemaContext context;
        public ReviewRepository(CinemaContext Context)
        {
            context = Context;
        }

        public ReviewModel AddReview(ReviewModel review)
        {
            this.context.ReviewModel.Add(review);
            this.context.SaveChanges();
            return review;
        }

        public void DeleteReview(int id)
        {
            ReviewModel review = this.context.ReviewModel.FirstOrDefault(a => a.Id == id);
            if(review != null)
            {
               this.context.ReviewModel.Remove(review);
               this.context.SaveChanges();
            }
            else
            {
                throw new Exception("Prob");
            }
            
        }

        public ReviewModel GetReviewById(int id)
        {
            ReviewModel review = this.context.ReviewModel.FirstOrDefault(a => a.Id == id);

            return review;
        }

        public IEnumerable<ReviewModel> GetReviewsByIdFilm(int idFilm)
        {
            List<ReviewModel> reviews = this.context.ReviewModel.Where(a => a.FilmModelId == idFilm).ToList();

            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    review.LoginModel = this.context.LoginModel.FirstOrDefault(user => user.Id == review.LoginModelId);
                }
            }

            return reviews;
        }

        public IEnumerable<ReviewModel> GetReviews()
        {
            List<ReviewModel> reviews = this.context.ReviewModel.ToList();

            if (reviews != null) {
                foreach(var review in reviews)
                {
                    review.LoginModel = this.context.LoginModel.FirstOrDefault(user => user.Id == review.LoginModelId);
                }
            }

            return reviews;
        }

        public ReviewModel UpdateReview(ReviewModel review)
        {
            this.context.ReviewModel.Update(review);
            this.context.SaveChanges();
            return review;
        }
    }
}
