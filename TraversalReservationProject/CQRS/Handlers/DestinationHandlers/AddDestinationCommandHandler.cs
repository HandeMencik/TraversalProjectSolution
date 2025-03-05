using DataAccess.Context;
using Entity.Concrete;
using TraversalReservationProject.CQRS.Commands.DestinationCommands;

namespace TraversalReservationProject.CQRS.Handlers.DestinationHandlers
{
    public class AddDestinationCommandHandler
    {
        private readonly TraversalContext _context;

        public AddDestinationCommandHandler(TraversalContext context)
        {
            _context = context;
        }
        public void Handle(AddDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                Capacity = command.Capacity,
                Status = true,
                Price = command.Price,
                DayNight = command.DayNight
            });
            _context.SaveChanges();
        }
    }
}
