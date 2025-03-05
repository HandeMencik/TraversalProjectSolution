using DataAccess.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalReservationProject.CQRS.Queries.GuideQueries;
using TraversalReservationProject.CQRS.Results.GuideResults;

namespace TraversalReservationProject.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly TraversalContext _context;

        public GetAllGuideQueryHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideId = x.GuideId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name                
            }).AsNoTracking().ToListAsync();
        }
    }
}
