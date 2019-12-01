using System.Web;
using System.Web.Optimization;

namespace FoodTeaShop1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Client
            bundles.Add(new ScriptBundle("~/bundles/jscore").Include(
                        "~/assets/client/js/jquery.min.js",
                        "~/assets/client/js/bootstrap.min.js",
                        "~/assets/client/js/owl.carousel.min.js",
                        "~/assets/client/js/mobile-menu.js",
                        "~/assets/client/js/jquery-ui.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                       "~/assets/client/js/controller/baseController.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscore2").Include(
                      "~/assets/client/js/main.js",
                      "~/assets/client/js/countdown.js",
                      "~/assets/client/js/revolution-slider.js"));

            bundles.Add(new StyleBundle("~/bundles/core").Include(
                      "~/assets/client/style.css",
                      "~/assets/client/css/bootstrap-social.css",
                      "~/assets/client/css/jquery-ui.css"
                      ));


          



        }
    }
}
 