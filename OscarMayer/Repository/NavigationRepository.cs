using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using OscarMayer.Repository.Interfaces;
using OscarMayer.Extensions;
using OscarMayer.Models.Navigation;

namespace OscarMayer.Repository
{
    public class NavigationRepository : INavigationRepository
    {
        public Item ContextItem { get; }
        public Item NavigationRoot { get; }

        public NavigationRepository(Item contextItem)
        {
            this.ContextItem = contextItem;
            this.NavigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (this.NavigationRoot == null)
            {
                throw new InvalidOperationException($"Cannot determine navigation root from '{this.ContextItem.Paths.FullPath}'");
            }
        }

        #region Public Methods

        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ??
                   Sitecore.Context.Site.GetContextItem(Templates.NavigationRoot.ID);
        }

        public NavigationItems GetLinkMenuItems(Item menuRoot)
        {
            if (menuRoot == null)
            {
                throw new ArgumentNullException(nameof(menuRoot));
            }
            return this.GetChildNavigationItems(menuRoot, 0, 0);
        }

        #endregion

        #region Private Methods

        private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
        {
            return item.IsDerived(Templates.Navigable.ID) && (forceShowInMenu || MainUtil.GetBool(item[Templates.Navigable.Fields.ShowInNavigation], false));
        }

        private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel)
        {
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children.Where(item => this.IncludeInNavigation(item)).Select(i => this.CreateNavigationItem(i, level, maxLevel));
            return new NavigationItems
            {
                Items = childItems.ToList()
            };
        }

        private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
        {
            return new NavigationItem
            {
                Item = item,
                Url = (item.IsDerived(Templates.Link.ID) ? item.LinkFieldUrl(Templates.Link.Fields.Link) : item.Url()),
                Target = (item.IsDerived(Templates.Link.ID) ? item.LinkFieldTarget(Templates.Link.Fields.Link) : ""),
                IsActive = this.IsItemActive(item),
                Children = this.GetChildNavigationItems(item, level + 1, maxLevel)
            };
        }

        private bool IsItemActive(Item item)
        {
            return this.ContextItem.ID == item.ID || this.ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
        }

        #endregion 
    }
}