using DataAccess.Context;
using Entity.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TraversalReservationProject.CQRS.Commands.GuideCommands;

namespace TraversalReservationProject.CQRS.Handlers.GuideHandlers
{
    public class AddGuideCommandHandler : IRequestHandler<AddGuideCommand,Unit>
    {
        private readonly TraversalContext _context;

        public AddGuideCommandHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Status = request.Status,

            });
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
