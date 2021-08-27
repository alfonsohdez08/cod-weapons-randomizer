using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponAttachmentsScraper : WebPageElementScraper<IHtmlSpanElement, IEnumerable<AttachmentCategory>>
    {
        public ModernWarfareWeaponAttachmentsScraper(IHtmlSpanElement spanElement) : base(spanElement)
        {
        }

        private IHtmlHeadingElement GetAttachmentsHeadingElement() => (IHtmlHeadingElement)HtmlElement.ParentElement;

        public override IEnumerable<AttachmentCategory> Scrap()
        {
            IHtmlHeadingElement headingElement = GetAttachmentsHeadingElement();
            var attachmentCategoryHeadingElement = (IHtmlHeadingElement)headingElement.NextElementSibling;

            while (attachmentCategoryHeadingElement.NextElementSibling != null &&
                attachmentCategoryHeadingElement.NextElementSibling is IHtmlUnorderedListElement){

                var listElement = (IHtmlUnorderedListElement)attachmentCategoryHeadingElement.NextElementSibling;

                attachmentCategoryHeadingElement = (IHtmlHeadingElement)attachmentCategoryHeadingElement.NextElementSibling.NextElementSibling;
            }

            throw new NotImplementedException();
        }
    }
}
