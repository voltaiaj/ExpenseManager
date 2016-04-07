using System.Web.Optimization;

namespace ExpenseManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularJS")
                            .Include("~/JS/lib/bower_components/angular/angular.js")
                            .Include("~/JS/lib/bower_components/angular-ui-router/release/angular-ui-router.js")
                            .Include("~/JS/lib/bower_components/Chart.js/Chart.js")
                            .Include("~/JS/lib/bower_components/angular-chart.js/angular-chart.js")
                            .Include("~/JS/lib/bower_components/d3/d3.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/ExpenseManager/js")
                            .Include("~/app/em.module.js")
                            .Include("~/app/home/home.module.js")
                            .Include("~/app/home/homeIndexController.js")
                            .Include("~/app/menuController.js")
                            .Include("~/app/filters/filters.module.js")
                            .Include("~/app/filters/filtersController.js")
                            .Include("~/app/filters/filtersFilters.js")
                            .Include("~/app/expressions/expressions.module.js")
                            .Include("~/app/expressions/expressionsController.js")
                            .Include("~/app/expenseSummary/expenseSummary.module.js")
                            .Include("~/app/expenseSummary/expenseSummaryController.js")
                            .Include("~/app/em.constants.js")
                            .Include("~/app/em.services.js")
                            .Include("~/app/utils/utils.module.js")
                            .Include("~/app/utils/urlHelper.service.js")
                            .Include("~/app/utils/dataTools.service.js")
                            .Include("~/app/utils/dataServiceHelper.service.js")
                );



            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                            .Include("~/Content/bootstrap.css")
                            .Include("~/Content/Site.css")
                            .Include("~/Content/app.css")
                            .Include("~/JS/lib/bower_components/angular-chart.js/dist/angular-chart.css")
                );
        }
    }
}
