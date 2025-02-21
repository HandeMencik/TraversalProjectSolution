using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using TraversalReservationProject.CQRS.Queries.DestinationQueries;
using TraversalReservationProject.CQRS.Results.DestinationResults;

namespace TraversalReservationProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly TraversalContext _context;

        public GetAllDestinationQueryHandler(TraversalContext context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values=_context.Destinations.Select(x=>new  GetAllDestinationQueryResult
            {
                id=x.DestinationId,
                city=x.City,
                capacity=x.Capacity,
                daynight=x.DayNight,
                price=x.Price,
            }).AsNoTracking().ToList();
            return values;


        }
    }
}
