using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMoviesByIdQueryHandler
    {
        private readonly MovieContext _context;

		public GetMoviesByIdQueryHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
		{
			var value = await _context.Movies.FindAsync(query.MovieId);

			return new GetMovieByIdQueryResult
			{
				
				Rating = value.Rating,
				Status = value.Status,
				Duration = value.Duration,
				CoverImgUrl = value.CoverImgUrl,
				CreatedYear = value.CreatedYear,
				Description = value.Description,
				RealeaseDate = value.RealeaseDate,
				Title = value.Title
			};
		}
	}
}
