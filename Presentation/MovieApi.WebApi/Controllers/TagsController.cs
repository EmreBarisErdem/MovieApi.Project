using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		private readonly IMediator _meditor;

		public TagsController(IMediator meditor)
		{
			_meditor = meditor;
		}

		[HttpGet]
		public async Task<IActionResult> TagList()
		{
			var values = await _meditor.Send(new GetTagQuery());

			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTag(CreateTagCommand command)
		{
			await _meditor.Send(command);
			return Ok("Ekleme işlemi başarılı");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTag(int id)
		{
			await _meditor.Send(new RemoveTagCommand(id));

			return Ok("Silme işlemi başarılı.");
		}

		[HttpGet("GetTag")]
		public async Task<IActionResult> GetTagById(int id)
		{
			var value = await _meditor.Send(new GetTagByIdQuery(id));

			return Ok(value);
		}


		[HttpPut]
		public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
		{
			await _meditor.Send(command);

			return Ok("Güncelleme işlemi başarılı.");
		}
	}
}
