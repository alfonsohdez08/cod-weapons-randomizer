using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    static class AngleSharpParentNodeExtensions
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
    }

    class HtmlElementNotFoundException: Exception
    {
        public string Selector { get; }

        public HtmlElementNotFoundException(string selector)
        {
            Selector = selector;
        }

        public override string ToString()
        {
            return $"Did not find any HTML element by using the selector: {Selector}.";
        }
    }
}
