﻿using System.Web;
using System.Web.Optimization;

namespace JooleApp.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Search/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/JooleStyles/SearchPage.css"));

            bundles.Add(new StyleBundle("~/Content/ProductSummary").Include(
                      "~/Content/CSS/ProductSummary.css",
                      "~/Content/CSS/RenderSearchPanel.css"));

            bundles.Add(new StyleBundle("~/Content/ProductSummary").Include(
                      "~/Content/CSS/ProductSummary.css",
                      "~/Content/CSS/RenderSearchPanel.css",
                      "~/Content/CSS/RenderProducts.css",
                      "~/Content/CSS/_ProductSummary.css"));

            bundles.Add(new ScriptBundle("~/bundles/ProductSummary").Include(
                "~/Scripts/JooleApp/ProductSummary.js"
                ));

            bundles.Add(new StyleBundle("~/ProductDetail/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/JooleStyles/ProductDetails.css"));

        }
    }
}
