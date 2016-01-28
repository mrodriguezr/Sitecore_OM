using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace OscarMayer.Models.Navigation
{
    public class NavigationItem
    {
        public Item Item { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Level { get; set; }
        public NavigationItems Children { get; set; }
        public string Target { get; set; }
    }
}