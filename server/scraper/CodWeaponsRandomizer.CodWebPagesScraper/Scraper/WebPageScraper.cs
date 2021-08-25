using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Io;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T> where T: class
    {
        protected readonly IDocument Document;

        public string WebPage { get; }

        protected WebPageScraper(string webPage)
        {
            WebPage = webPage;
            Document = ReadWebPage();
        }

        private IDocument ReadWebPage()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            
            return context.OpenAsync(WebPage).Result;
        }

        public abstract T Scrap();
    }
}
