using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using System.Security.AccessControl;

namespace MovieApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CastsController : ControllerBase
	{
		private readonly IMediator _meditor;

		public CastsController(IMediator meditor)
		{
			_meditor = meditor;
		}

		[HttpGet]
		public async Task<IActionResult> CastList()
		{
			var values = await _meditor.Send(new GetCastQuery());

			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCast(CreateCastCommand command)
		{
			await _meditor.Send(command);
			return Ok("Ekleme işlemi başarılı");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCast(int id)
		{
			await _meditor.Send(new RemoveCastCommand(id));

			return Ok("Silme işlemi başarılı.");
		}

		[HttpGet("GetCastById")]
		public async Task<IActionResult> GetCastById(int id)
		{
			var value = await _meditor.Send(new GetCastByIdQuery(id));

			return Ok(value);
		}


		[HttpPut]
		public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
		{
			await _meditor.Send(command);

			return Ok("Güncelleme işlemi başarılı.");
		}

	}
}
