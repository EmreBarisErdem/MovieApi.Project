﻿using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
	public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
	{

		private readonly MovieContext _context;

		public CreateTagCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
		{
			await _context.Tags.AddAsync(new Domain.Entities.Tag
			{
				Title = request.Title,

			});
			await _context.SaveChangesAsync();
		}
	}
}
