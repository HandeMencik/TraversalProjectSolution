using DataAccess.Context;
using MediatR;
using TraversalReservationProject.CQRS.Queries.GuideQueries;
using TraversalReservationProject.CQRS.Results.GuideResults;

namespace TraversalReservationProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly TraversalContext _context;

        public GetGuideByIdQueryHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _context.Guides.FindAsync(request.id);
            return new GetGuideByIdQueryResult
            {
                GuideId = values.GuideId,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Name = values.Name
            };
        }
    }
}
