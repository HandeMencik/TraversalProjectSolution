using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.CQRS.Commands.DestinationCommands;
using TraversalReservationProject.CQRS.Handlers.DestinationHandlers;
using TraversalReservationProject.CQRS.Queries.DestinationQueries;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly AddDestinationCommandHandler _addDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;


        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, AddDestinationCommandHandler addDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _addDestinationCommandHandler = addDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var results = _getAllDestinationQueryHandler.Handle();
            return View(results);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(result);
        }
        [HttpPost]
        public IActionResult Get(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handler(command);
            return RedirectToAction("/Admin/DestinationCQRS/Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddDestinationCommand command)
        {
             _addDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _deleteDestinationCommandHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
