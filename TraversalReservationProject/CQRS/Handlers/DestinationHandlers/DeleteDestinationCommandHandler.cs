using DataAccess.Context;
using TraversalReservationProject.CQRS.Commands.DestinationCommands;

namespace TraversalReservationProject.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly TraversalContext _context;

        public DeleteDestinationCommandHandler(TraversalContext context)
        {
            _context = context;
        }
        public void Handle(DeleteDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.Id);
            if (value != null)
            {
                _context.Destinations.Remove(value);
                _context.SaveChanges();
            }
        }
    }
}
