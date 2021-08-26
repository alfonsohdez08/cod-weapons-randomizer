using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T> where T: class
    {
        protected readonly IHtmlDocument HtmlDocument;

        protected WebPageScraper(string webPageUrl)
        {
            HtmlDocument = LoadWebPage(webPageUrl);
        }

        private static IHtmlDocument LoadWebPage(string webPageUrl)
        {
            string webPageContent = DownloadWebPage(webPageUrl);

            return new HtmlParser().ParseDocument(webPageContent);
        }

        private static string DownloadWebPage(string webPageUrl)
        {
            using var httpClient = new HttpClient();
            HttpResponseMessage httpResponse = httpClient.GetAsync(webPageUrl).Result;

            return httpResponse.Content.ReadAsStringAsync().Result;
        }

        public abstract T Scrap();
    }
}
