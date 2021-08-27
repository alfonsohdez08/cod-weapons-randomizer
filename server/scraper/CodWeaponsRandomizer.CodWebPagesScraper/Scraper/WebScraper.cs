using AngleSharp;
using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebScraper<THtmlElementType, TResult>
        where THtmlElementType: IDocument
        where TResult : class
    {
        protected readonly THtmlElementType ElementDom;

        protected WebScraper(Uri url)
        {
            ElementDom = LoadWebPage(url);
        }

        protected WebScraper(string htmlElement)
        {
            ElementDom = LoadHtmlElement(htmlElement);
        }

        private static THtmlElementType LoadWebPage(Uri url)
        {
            using var httpClient = new HttpClient();
            var httpResponse = httpClient.GetAsync(url).Result;

            return LoadHtmlElement(httpResponse.Content.ReadAsStringAsync().Result);
        }

        private static THtmlElementType LoadHtmlElement(string htmlElement)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            return (THtmlElementType)context.OpenAsync(req => req.Content(htmlElement)).Result;
        }

        public abstract TResult Scrap();
    }
}
