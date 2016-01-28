using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data;

namespace OscarMayer
{
    public struct Templates
    {
        public struct NavigationRoot
        {
            public static readonly ID ID = new ID("{7B2D242F-CD66-4E2C-B65B-C044AFC07537}");
        }
        
        public struct Navigable
        {
            public static readonly ID ID = new ID("{D9CE04BA-6540-4F32-B1D9-3724B20497CA}");

            public struct Fields
            {
                public static readonly ID ShowInNavigation = new ID("{49642A1B-3E14-407C-943A-2C097A12D997}");
                public static readonly ID NavigationTitle = new ID("{2436191F-5525-48C0-9305-513065D135FD}");
                public const string NavigationTitle_FieldName = "NavigationTitle";
            }
        }

        public struct Link
        {
            public static readonly ID ID = new ID("{17D92231-82B5-41E5-A850-E01933972891}");

            public struct Fields
            {
                public static readonly ID Link = new ID("{E196352D-2AD5-4532-9338-0F2430FF5E68}");
            }
        }

        public struct LinkMenuItem
        {
            public static readonly ID ID = new ID("{7B997A48-FCDD-4FFA-8A20-5C43BD13C481}");

            public struct Fields
            {
                public static readonly ID Icon = new ID("{0C218FA8-7326-4099-9B27-FB002DE526A3}");
                public static readonly ID DividerBefore = new ID("{89471727-5A9D-4287-AB04-85D7EA5936FD}");
            }
        }

    }
}