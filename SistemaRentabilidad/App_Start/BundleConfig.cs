using System.Web;
using System.Web.Optimization;

namespace SistemaRentabilidad
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            ScriptBundle scriptBundle = new ScriptBundle("~/js");
            string[] scriptArray =
            {
             "~/Scripts/jquery-1.12.4.js",
                       "~/Scripts/jquery-1.12.4.min.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                       "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/datatables/jquery.datatables.js",
                       "~/Scripts/datatables/datatables.bootstrap.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/traducirmes.js",
                       "~/Scripts/respond.js",
                       "~/Scripts/bootbox.js",
                       "~/Scripts/toastr.js",
                       "~/Scripts/ordenFechas.js",
                       "~/Scripts/cargar.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                       "~/Scripts/autosize.js",
                       "~/Scripts/bootstrap-select.min.js", "~/Scripts/awesomplete.js",
                       "~/Scripts/maxlength.js","~/Scripts/bootstrap-datepicker.js","~/Scripts/locales/bootstrap-datepicker.es.min.js",
                       "~/Scripts/i18n/defaults-ar_AR.min.js"
        };
            scriptBundle.Include(scriptArray);
            scriptBundle.IncludeDirectory("~/Scripts/", "*.js");
            bundles.Add(scriptBundle);

          

//            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
//                         "~/Scripts/jquery-1.12.4.js",
//                       "~/Scripts/jquery-1.12.4.min.js",
//                        "~/Scripts/jquery-ui-1.12.1.js",
//                       "~/Scripts/jquery-ui-1.12.1.min.js",
//                        "~/Scripts/jquery.unobtrusive-ajax.js",
//                       "~/Scripts/bootstrap.js",
//                       "~/Scripts/datatables/jquery.datatables.js",
//                       "~/Scripts/datatables/datatables.bootstrap.js",
//                       "~/Scripts/bootstrap.min.js",
//                       "~/Scripts/respond.js",
//                       "~/Scripts/bootbox.js",
//                       "~/Scripts/toastr.js",
//                       "~/Scripts/ordenFechas.js",
//                       "~/Scripts/cargar.js",
//                        "~/Scripts/jquery.unobtrusive-ajax.js",
//                       "~/Scripts/autosize.js",
//                       "~/Scripts/bootstrap-select.min.js", "~/Scripts/awesomplete.js",
//                       "~/Scripts/maxlength.js",
//                       "~/Scripts/i18n/defaults-ar_AR.min.js", "~/Scripts/Monthpicker.js"


//));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Styles/css").Include(
            "~/Content/bootstrap-flaty.css", "~/Content/css/awesomplete.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap-select.css.map",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/content/toastr.css",
                       "~/Content/css/jquery-ui.min.css", "~/Content/Site.css", "~/Content/hover.css", "~/Content/bootstrap-datepicker.css"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap-flaty.css", "~/Content/css/awesomplete.css",
            //          "~/Content/bootstrap-select.css",
            //          "~/Content/bootstrap-select.css.map",
            //          "~/Content/datatables/css/datatables.bootstrap.css",
            //          "~/content/toastr.css",
            //          "~/Content/site.css", "~/Content/css/jquery-ui.min.css", "~/Content/Monthpicker.css"));
        }
    }
}
