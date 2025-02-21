using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.CQRS.Handlers.DestinationHandlers;
using TraversalReservationProject.CQRS.Queries.DestinationQueries;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationCQRSConrtoller : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;


        public DestinationCQRSConrtoller(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler = null)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }
        public IActionResult Get(int id)
        {
            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }
    }
}
