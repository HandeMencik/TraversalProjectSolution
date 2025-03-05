using MediatR;
using TraversalReservationProject.CQRS.Results.GuideResults;

namespace TraversalReservationProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public int id { get; set; }

        public GetGuideByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
