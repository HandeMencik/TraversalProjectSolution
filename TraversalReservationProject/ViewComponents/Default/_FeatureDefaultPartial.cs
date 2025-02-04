using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _FeatureDefaultPartial:ViewComponent
    {
        //private readonly IFeatureService _featureService;

        //public _FeatureDefaultPartial(IFeatureService featureService)
        //{
        //    _featureService = featureService;
        //}

        public IViewComponentResult Invoke()
        {
            //var results = _featureService.GetAll();
            //if (results.Success)
            //{
            //    return View(results.Data);
            //}
          
            return View();
        }
    }
}
