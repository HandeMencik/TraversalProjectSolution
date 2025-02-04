using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _PopularDestinationDefaultPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestinationDefaultPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var results = _destinationService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }

    }
}
