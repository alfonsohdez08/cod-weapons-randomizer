﻿namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    abstract class WikiScraper<T> : WebPageScraper<T> where T : class
    {
        private const string CallOfDutyFanDomPage = "https://callofduty.fandom.com";

        protected WikiScraper(string path) : base($"{CallOfDutyFanDomPage}/{path}")
        {
        }
    }
}
