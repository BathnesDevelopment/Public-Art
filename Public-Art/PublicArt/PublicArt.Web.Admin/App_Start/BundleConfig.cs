using System.Web;
using System.Web.Optimization;

namespace PublicArt.Web.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/bootstrap-toggle.min.js",
                "~/Scripts/featherlight.min.js",
                "~/Scripts/leaflet-0.7.3.min.js",
                "~/Scripts/jquery-ui.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/thirdparty").Include(
                "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                "~/Content/bootstrap-toggle.min.css",
                "~/Content/featherlight.min.css",
                "~/Content/leaflet.css",
                "~/Content/jquery-ui.min.css"
            ));
        }
    }
}
