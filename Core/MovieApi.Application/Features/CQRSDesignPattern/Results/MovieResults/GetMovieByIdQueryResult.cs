﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults
{
    public class GetMovieByIdQueryResult
    {
		public int MovieId { get; set; }

		public string Title { get; set; }

		public string CoverImgUrl { get; set; }

		public decimal Rating { get; set; }

		public string Description { get; set; }

		public int Duration { get; set; }

		public DateTime RealeaseDate { get; set; }

		public string CreatedYear { get; set; }

		public bool Status { get; set; }
	}
}
