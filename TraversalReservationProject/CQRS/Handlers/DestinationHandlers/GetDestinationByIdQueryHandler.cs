using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.CQRS.Queries.DestinationQueries;
using TraversalReservationProject.CQRS.Results.DestinationResults;

namespace TraversalReservationProject.CQRS.Handlers.DestinationHandlers
{
    [Area("Admin")]
    public class GetDestinationByIdQueryHandler
    {
        private readonly TraversalContext _context;

        public GetDestinationByIdQueryHandler(TraversalContext context)
        {
            _context = context;
        }
        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationId,
                City= values.City,
                DayNight= values.DayNight

            };


        }
    }
}
