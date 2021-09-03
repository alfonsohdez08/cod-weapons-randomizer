using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    class WeaponAttachmentsScraper : WebPageComponentScraper<IHtmlHeadingElement, List<AttachmentType>>
    {
        private Set<AttachmentType>? _attachmentTypeSet;

        public WeaponAttachmentsScraper(IHtmlHeadingElement headingElement) : base(headingElement)
        {
        }

        private static List<GameItem> ParseAttachments(IHtmlUnorderedListElement unorderedListElement)
        {
            IEnumerable<GameItem> attachments = unorderedListElement.Children.Select(c => new GameItem(c.Children[0].TextContent));

            var attachmentSet = new Set<GameItem>();
            attachmentSet.AddRange(attachments);

            return attachmentSet.ToList();
        }

        public override List<AttachmentType> Scrap()
        {
            _attachmentTypeSet = new Set<AttachmentType>();

            var attachmentTypeHeadingElement = (IHtmlHeadingElement)HtmlElement.NextElementSibling!;
            while (attachmentTypeHeadingElement != null && attachmentTypeHeadingElement.NextElementSibling != null &&
                attachmentTypeHeadingElement.NextElementSibling is IHtmlUnorderedListElement){

                var attachmentType = new AttachmentType(attachmentTypeHeadingElement.Children[0].TextContent)
                {
                    Attachments = ParseAttachments((IHtmlUnorderedListElement)attachmentTypeHeadingElement.NextElementSibling)
                };
                _attachmentTypeSet.Add(attachmentType);

                attachmentTypeHeadingElement = attachmentTypeHeadingElement.NextElementSibling.NextElementSibling as IHtmlHeadingElement;
            }

            return _attachmentTypeSet.ToList();
        }
    }
}
