using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult _SidebarAdminPartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarAdminPartial()
        {
            return PartialView();
        }
        public PartialViewResult _FooterAdminPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptAdminPartial()
        {
            return PartialView();
        }
    }
}

