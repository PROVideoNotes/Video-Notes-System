using System.Web;
using System.Web.Optimization;

namespace VideoNotes.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js"            
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/youtube").Include(
                "~/Scripts/youtube.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                "~/Scripts/Slider/tcycle.js"));

            bundles.Add(new ScriptBundle("~/bundles/drawingTools").Include(
                "~/Scripts/Drawing/tools/brushTool.js",
                 "~/Scripts/Drawing/tools/bigBrush.js",
                 "~/Scripts/Drawing/tools/sprayCanTool.js",
                 "~/Scripts/Drawing/tools/rectTool.js",
                 "~/Scripts/Drawing/tools/triangleTool.js",
                 "~/Scripts/Drawing/tools/loadImage.js",
                 "~/Scripts/Drawing/tools/savePicture.js",
                 "~/Scripts/Drawing/tools/cloudTool.js",
                 "~/Scripts/Drawing/tools/starTool.js",
                 "~/Scripts/Drawing/tools/ellipseTool.js",
                 "~/Scripts/Drawing/tools/pickColor.js",
                 "~/Scripts/Drawing/tools/paintBucketTool.js",
                 "~/Scripts/Drawing/tools/writeTextTool.js",
                 "~/Scripts/Drawing/tools/changeSizing.js",
                 "~/Scripts/Drawing/tools/eyeDropperTool.js",
                 "~/Scripts/Drawing/tools/eraserTool.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/drawingPanel").Include(
                     "~/Scripts/Drawing/logger.js",
                     "~/Scripts/Drawing/main.js",
                     "~/Scripts/Drawing/engine.js"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/drawingUI").Include(
                      "~/Scripts/Drawing/ui-components/sideBar.js",
                      "~/Scripts/Drawing/ui-components/colorsSlider.js",
                      "~/Scripts/Drawing/ui-components/load.js",
                      "~/Scripts/Drawing/ui-components/colorPickerJqueryUI.js",
                      "~/Scripts/Drawing/ui-components/alphaChanger.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/drawing/css").Include(
                     "~/Content/drawing.css",
                     "~/Content/jQuerySmooth.css"));


        }
    }
}
