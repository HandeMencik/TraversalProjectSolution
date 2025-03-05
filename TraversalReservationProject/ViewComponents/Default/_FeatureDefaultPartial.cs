using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _FeatureDefaultPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _FeatureDefaultPartial(IDestinationService destinationService)
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
        //private readonly IFeatureService _featureService;

        //public _FeatureDefaultPartial(IFeatureService featureService)
        //{
        //    _featureService = featureService;
        //}

        //public IViewComponentResult Invoke()
        //{
        //    var results = _featureService.GetAll();
        //    if (results.Success)
        //    {
        //        return View(results.Data);
        //    }

        //    return View();
        //}
    }
}
