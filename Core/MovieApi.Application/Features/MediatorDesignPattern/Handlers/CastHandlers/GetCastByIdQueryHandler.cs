using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
	public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
	{
		private readonly MovieContext _context;

		public GetCastByIdQueryHandler(MovieContext movieContext)
		{
			_context = movieContext;
		}

		public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _context.Casts.FindAsync(request.CastId);

			return new GetCastByIdQueryResult
			{
				Biography = value.Biography,
				CastId = value.CastId,	
				ImageUrl = value.ImageUrl,
				Name = value.Name,
				Overview = value.Overview,
				Surname = value.Surname,
				Title = value.Title,
			};
		}
	}
}
