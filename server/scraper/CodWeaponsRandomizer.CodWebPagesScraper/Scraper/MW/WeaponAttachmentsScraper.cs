using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponAttachmentsScraper : WebPageComponentScraper<IHtmlHeadingElement, List<AttachmentType>>
    {
        private readonly Set<AttachmentType> _attachmentTypeSet;

        public WeaponAttachmentsScraper(IHtmlHeadingElement headingElement) : base(headingElement)
        {
            _attachmentTypeSet = new Set<AttachmentType>();
        }

        private static List<GameItem> ParseAttachments(IHtmlUnorderedListElement unorderedListElement)
        {
            var attachmentSet = new Set<GameItem>();

            IEnumerable<GameItem> attachments = unorderedListElement.Children.Select(c => new GameItem(c.Children[0].TextContent));
            foreach (GameItem attachment in attachments)
                attachmentSet.Add(attachment);

            return attachmentSet.ToList();
        }

        public override List<AttachmentType> Scrap()
        {            
            var attachmentCategoryHeadingElement = (IHtmlHeadingElement)HtmlElement.NextElementSibling!;
            while (attachmentCategoryHeadingElement != null && attachmentCategoryHeadingElement.NextElementSibling != null &&
                attachmentCategoryHeadingElement.NextElementSibling is IHtmlUnorderedListElement){

                var attachmentType = new AttachmentType(attachmentCategoryHeadingElement.Children[0].TextContent)
                {
                    Attachments = ParseAttachments((IHtmlUnorderedListElement)attachmentCategoryHeadingElement.NextElementSibling)
                };
                _attachmentTypeSet.Add(attachmentType);

                attachmentCategoryHeadingElement = attachmentCategoryHeadingElement.NextElementSibling.NextElementSibling as IHtmlHeadingElement;
            }

            return _attachmentTypeSet.ToList();
        }
    }
}
