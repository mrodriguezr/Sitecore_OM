using System;
using System.Web.Mvc;
using OscarMayer.Repository;
using OscarMayer.Repository.Interfaces;
using Sitecore.Mvc.Presentation;

namespace OscarMayer.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationRepository _navigationRepository;

        public NavigationController() : this(new NavigationRepository(RenderingContext.Current.Rendering.Item))
        {
        }

        public NavigationController(INavigationRepository navigationRepository)
        {
            this._navigationRepository = navigationRepository;
        }

        public ActionResult LinkMenu()
        {
            if (String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return null;
            }
            var item = RenderingContext.Current.Rendering.Item;
            var items = this._navigationRepository.GetLinkMenuItems(item);
            return this.View("LinkMenu", items);
        }
    }
}