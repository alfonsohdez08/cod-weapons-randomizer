using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponAttachmentsScraper : WebPageElementScraper<IHtmlSpanElement, IEnumerable<AttachmentCategory>>
    {
        public ModernWarfareWeaponAttachmentsScraper(IHtmlSpanElement spanElement) : base(spanElement)
        {
        }

        private IHtmlHeadingElement GetAttachmentsHeadingElement() => (IHtmlHeadingElement)HtmlElement.ParentElement;

        private static IEnumerable<string> ParseAttachments(IHtmlUnorderedListElement unorderedListElement)
            => unorderedListElement.Children.Select(c => c.Children[0].TextContent);

        public override IEnumerable<AttachmentCategory> Scrap()
        {
            var attachmentCategories = new List<AttachmentCategory>();

            IHtmlHeadingElement headingElement = GetAttachmentsHeadingElement();
            
            var attachmentCategoryHeadingElement = (IHtmlHeadingElement)headingElement.NextElementSibling;
            while (attachmentCategoryHeadingElement != null && attachmentCategoryHeadingElement.NextElementSibling != null &&
                attachmentCategoryHeadingElement.NextElementSibling is IHtmlUnorderedListElement){

                var attachmentCategory = new AttachmentCategory(attachmentCategoryHeadingElement.Children[0].TextContent)
                {
                    AttachmentVariants = ParseAttachments((IHtmlUnorderedListElement)attachmentCategoryHeadingElement.NextElementSibling)
                };
                attachmentCategories.Add(attachmentCategory);

                attachmentCategoryHeadingElement = attachmentCategoryHeadingElement.NextElementSibling.NextElementSibling as IHtmlHeadingElement;
            }

            return attachmentCategories;
        }
    }
}
