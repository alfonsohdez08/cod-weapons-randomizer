using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponAttachmentsScraper : WebPageElementScraper<IHtmlHeadingElement, IEnumerable<AttachmentCategory>>
    {
        public WeaponAttachmentsScraper(IHtmlHeadingElement headingElement) : base(headingElement)
        {
        }

        private static IEnumerable<string> ParseAttachments(IHtmlUnorderedListElement unorderedListElement)
            => unorderedListElement.Children.Select(c => c.Children[0].TextContent);

        public override IEnumerable<AttachmentCategory> Scrap()
        {
            var attachmentCategories = new List<AttachmentCategory>();
            
            var attachmentCategoryHeadingElement = (IHtmlHeadingElement)HtmlElement.NextElementSibling;
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
