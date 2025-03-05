using MediatR;
using TraversalReservationProject.CQRS.Results.DestinationResults;
using TraversalReservationProject.CQRS.Results.GuideResults;

namespace TraversalReservationProject.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
