using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
	public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
	{
		private readonly MovieContext _context;

		public CreateCastCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
		{
			await _context.Casts.AddAsync(new Domain.Entities.Cast
			{
				Biography = request.Biography,
				ImageUrl = request.ImageUrl,
				Overview = request.Overview,
				Name = request.Name,
				Surname = request.Surname,
				Title = request.Title,
			});
			await _context.SaveChangesAsync();
		}
	}
}
