using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

		public GetMovieQueryHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task<List<GetMovieQueryResult>> Handle()
		{
			var values = await _context.Movies.ToListAsync();

			return values.Select(x => new GetMovieQueryResult
			{
				MovieId = x.MovieId,
				Rating = x.Rating,
				Status = x.Status,
				Duration = x.Duration,
				CoverImgUrl = x.CoverImgUrl,
				CreatedYear = x.CreatedYear,
				Description = x.Description,
				RealeaseDate = x.RealeaseDate,
				Title = x.Title

			}).ToList();
		}
	}
}
