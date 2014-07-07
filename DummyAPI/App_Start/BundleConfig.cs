using System.Web;
using System.Web.Optimization;

namespace DummyAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularapp").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/app/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app/create").Include(
                "~/scripts/app/controllers/CreateServiceController.js",
                "~/scripts/app/Directives/ContentTypeInfoStack.js",
                "~/scripts/app/Services/WebServiceGenerator.js",
                "~/scripts/app/Services/Validation/xmlValidator.js",
                "~/scripts/app/Services/Validation/contentTypeValidator.js",
                "~/scripts/app/Services/Validation/JsonValidator.js",
                "~/Scripts/zeroclipboard/ZeroClipboard.min.js",
                "~/Scripts/zeroclipboard/ServiceUrlCopy.js"
                ));
        }
    }
}
