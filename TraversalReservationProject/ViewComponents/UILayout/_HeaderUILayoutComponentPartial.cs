using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.UILayout
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
