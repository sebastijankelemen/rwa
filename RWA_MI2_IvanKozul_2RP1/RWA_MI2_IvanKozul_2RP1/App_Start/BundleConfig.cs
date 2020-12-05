using System.Web;
using System.Web.Optimization;

namespace CodeRepository.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                      "~/Scripts/jquery-3.0.0.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/knockout-3.4.2.js",
                      "~/jsgrid-1.5.3/jsgrid.js",
                      "~/Scripts/Webpages/Layout.js"));

            bundles.Add(new StyleBundle("~/bundles/Style/layout").Include(
                      "~/Content/bootstrap.css",
                      "~/jsgrid-1.5.3/jsgrid.css",
                      "~/jsgrid-1.5.3/jsgrid-theme.css",
                      "~/Content/Webpages/Layout.css"));
        }
    }
}