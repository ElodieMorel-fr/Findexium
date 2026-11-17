using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<RatingResponse> CreateAsync(RatingRequest ratingRequest)
        {
            Rating rating = MapToEntity(ratingRequest);
            

            await _ratingRepository.AddAsync(rating);
            return MapToResponse(rating);
        }

        private static Rating MapToEntity(RatingRequest ratingRequest, Rating? rating = null)
        {
            if (rating == null)
                rating = new Rating();

            rating.MoodysRating = ratingRequest.MoodysRating;
            rating.SandPRating = ratingRequest.SandPRating;
            rating.FitchRating = ratingRequest.FitchRating;
            rating.OrderNumber = ratingRequest.OrderNumber;

            return rating;

        }

        private static RatingResponse MapToResponse(Rating rating)
        {
            return new RatingResponse()
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber,

            };

        }
    }
}
