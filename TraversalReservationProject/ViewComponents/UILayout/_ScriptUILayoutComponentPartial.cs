using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.UILayout
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
