using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    static class AngleSharpExtensions
    {
        public static T SelectFirst<T>(this IParentNode parentNode, string selector) where T: class, IElement
        {
            var element = parentNode.QuerySelector<T>(selector);
            if (element == null)
                throw new HtmlElementNotFoundException(selector);

            return element;
        }

        public static IEnumerable<T> SelectAll<T>(this IParentNode parentNode, string selector) where T: class, IElement
        {
            var elements = parentNode.QuerySelectorAll<T>(selector);
            if (elements == null || !elements.Any())
                throw new HtmlElementNotFoundException(selector);

            return elements;
        }

        //public static IEnumerable<IHtmlTableRowElement> FirstRows(this IHtmlTableElement tableElement, int count)
        //{
        //    tableElement.Rows

        //    throw new NotImplementedException();
        //}

        //public static IEnumerable<IHtmlTableRowElement> GetRow(this IHtmlTableElement tableElment, int index)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
