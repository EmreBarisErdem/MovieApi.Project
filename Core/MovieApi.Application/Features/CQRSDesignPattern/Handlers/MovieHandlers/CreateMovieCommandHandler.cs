using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

		public CreateMovieCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async void Handle(CreateMovieCommand command) 
		{
			await _context.Movies.AddAsync(new Movie
			{
				CoverImgUrl = command.CoverImgUrl,
				CreatedYear = command.CreatedYear,
				Description = command.Description,
				Duration = command.Duration,
				Rating = command.Rating,
				RealeaseDate = command.RealeaseDate,
				Status = command.Status,
				Title = command.Title

			});
			await _context.SaveChangesAsync();
		}
	}
}
