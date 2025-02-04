using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.MemberDashboard
{
    public class _PlatformSettingComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
