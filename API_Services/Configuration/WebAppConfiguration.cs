using Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Services.Configuration
{
    public class WebAppConfiguration : IWebAppConfiguration
    {
        private static volatile IWebAppConfiguration instance;
        private static readonly object SyncRoot = new object();
        public static IWebAppConfiguration Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = IoCContainerHolder.UnityContainer.Resolve<IWebAppConfiguration>();
                    }
                }

                return instance;
            }
        }
    }
}