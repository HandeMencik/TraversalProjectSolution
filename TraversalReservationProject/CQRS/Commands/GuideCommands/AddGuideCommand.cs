using MediatR;

namespace TraversalReservationProject.CQRS.Commands.GuideCommands
{
    public class AddGuideCommand:IRequest<Unit>
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
