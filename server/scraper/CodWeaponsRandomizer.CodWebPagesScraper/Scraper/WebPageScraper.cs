using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T> where T: class
    {
        private const string CodWikiFandomPage = "https://callofduty.fandom.com";

        protected readonly IHtmlDocument HtmlDocument;

        protected WebPageScraper()
        {
            HtmlDocument = LoadWebPage(CodWikiFandomPage);
        }

        protected WebPageScraper(string path)
        {
            HtmlDocument = LoadWebPage(CodWikiFandomPage + $"/{path}");
        }

        private static IHtmlDocument LoadWebPage(string webPageUrl)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = context.OpenAsync(webPageUrl).Result;

            return (IHtmlDocument)document;
        }

        public abstract T Scrap();
    }
}
