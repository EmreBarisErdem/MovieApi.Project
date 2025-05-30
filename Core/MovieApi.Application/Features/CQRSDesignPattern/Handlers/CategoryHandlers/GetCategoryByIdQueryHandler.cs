﻿using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _context;

		public GetCategoryByIdQueryHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task<GetCategortyByIdQueryResult> Handle(GetCategoryByIdQuery query)
		{
			var value = await _context.Categories.FindAsync(query.CategoryId);

			return new GetCategortyByIdQueryResult
			{
				CategoryId = value.CategoryId,
				CategoryName = value.CategoryName
			};
		}
	}
}
