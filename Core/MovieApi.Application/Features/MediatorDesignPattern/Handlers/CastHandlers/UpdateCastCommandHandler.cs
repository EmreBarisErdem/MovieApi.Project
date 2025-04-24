using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
	public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
	{
		private readonly MovieContext _context;

		public UpdateCastCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
		{
			var values = await _context.Casts.FindAsync(request.CastId);

			values.Surname = request.Surname;
			values.Name = request.Name;
			values.Overview = request.Overview;
			values.ImageUrl = request.ImageUrl;
			values.Biography = request.Biography;
			values.Title = request.Title;

			await _context.SaveChangesAsync();
		}
	}
}
