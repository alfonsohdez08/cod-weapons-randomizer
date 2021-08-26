using AngleSharp;
using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T> where T: class
    {
        protected readonly IDocument HtmlDocument;

        protected WebPageScraper(string webPageUrl)
        {
            HtmlDocument = LoadWebPage(webPageUrl);
        }

        private static IDocument LoadWebPage(string webPageUrl)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            
            return context.OpenAsync(webPageUrl).Result;
        }

        public abstract T Scrap();
    }
}
