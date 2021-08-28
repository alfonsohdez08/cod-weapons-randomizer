using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    class WeaponAttachmentScraper : WebPageElementScraper<IHtmlSpanElement, IEnumerable<AttachmentCategory>>
    {
        public WeaponAttachmentScraper(IHtmlSpanElement spanElement) : base(spanElement)
        {
        }

        public override IEnumerable<AttachmentCategory> Scrap()
        {
            throw new NotImplementedException();
        }
    }
}
