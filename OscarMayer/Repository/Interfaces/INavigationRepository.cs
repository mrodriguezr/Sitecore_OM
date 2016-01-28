using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OscarMayer.Models.Navigation;
using Sitecore.Data.Items;

namespace OscarMayer.Repository.Interfaces
{
    public interface INavigationRepository
    {
        NavigationItems GetLinkMenuItems(Item menuItem);
    }
}
