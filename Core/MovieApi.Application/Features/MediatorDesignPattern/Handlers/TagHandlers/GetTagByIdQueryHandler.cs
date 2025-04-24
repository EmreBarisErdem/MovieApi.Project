using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
	public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
	{
		private readonly MovieContext _context;

		public GetTagByIdQueryHandler(MovieContext movieContext)
		{
			_context = movieContext;
		}

		public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _context.Tags.FindAsync(request.TagId);

			return new GetTagByIdQueryResult
			{
				Title = value.Title,

			};
		}
	}
}
