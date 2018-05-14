using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Unity_WebAPI2_ADO.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/style")
                        .Include("~/bundles/styles.*"));
            bundles.Add(new ScriptBundle("~/Bundles/script")
                        .Include(
                        "~/bundles/inline.*",
                        "~/bundles/polyfills.*",
                        "~/bundles/scripts.*",
                        "~/bundles/vendor.*",
                        "~/bundles/main.*"));

        }
    }
}