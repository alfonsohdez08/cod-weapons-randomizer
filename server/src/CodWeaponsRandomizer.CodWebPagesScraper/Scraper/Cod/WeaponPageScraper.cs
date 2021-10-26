using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class WeaponPageScraper : WebPageScraper
    {
        public WeaponPageScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        private bool IsExclusiveWeapon() => HtmlDocument.GetElementById(CodGameElementId) == null;

        private IHtmlElement GetWeaponAsideElement()
        {
            IElement asideElement = IsExclusiveWeapon() ?
                HtmlDocument.SelectFirst<IElement>(Html.Tags.Aside) : GetAsideElementForNonExclusiveWeapon();

            IElement GetAsideElementForNonExclusiveWeapon()
            {
                string asideHtmlTag = Html.Tags.Aside.ToUpper();
                var element = HtmlDocument.GetElementById(CodGameElementId)!.ParentElement;

                while (element!.TagName != asideHtmlTag)
                    element = element.NextElementSibling;

                return element;
            }

            return (IHtmlElement)asideElement!;
        }

        private IHtmlHeadingElement? FindWeaponAttachmentHeadings()
        {
            IHtmlHeadingElement? heading;
            if (IsExclusiveWeapon())
                heading = HtmlDocument.QuerySelector("#Attachments")?.ParentElement as IHtmlHeadingElement;
            else
                heading = FindNonExclusiveWeaponAttachmentsHeading();

            IHtmlHeadingElement? FindNonExclusiveWeaponAttachmentsHeading()
            {
                var element = HtmlDocument.GetElementById(CodGameElementId)?.ParentElement;

                for (; element != null; element = element.NextElementSibling)
                    if (element is IHtmlHeadingElement h && h.Children[0] is IHtmlSpanElement s
                        && s.Text() == "Attachments")
                        break;

                return element as IHtmlHeadingElement;
            }

            return heading;
        }

        private List<AttachmentType>? GetWeaponSupportedAttachments()
        {
            IHtmlHeadingElement? element = FindWeaponAttachmentHeadings();
            return element != null ? new WeaponAttachmentsScraper(element).Scrap() : null;
        }

        public Weapon ScrapWeapon()
        {
            IHtmlElement asideElement = GetWeaponAsideElement();

            Weapon weapon = new WeaponScraper(asideElement).Scrap();
            var supportedAttachments = GetWeaponSupportedAttachments();
            if (supportedAttachments != null)
                weapon.SupportedAttachments = supportedAttachments;

            return weapon;
        }

        public abstract string CodGameElementId { get; }
    }
}
