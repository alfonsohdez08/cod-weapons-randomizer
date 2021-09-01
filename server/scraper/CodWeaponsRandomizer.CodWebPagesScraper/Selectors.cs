using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    static class Selectors
    {
        public static readonly string TableAnchors;

        static Selectors()
        {
            TableAnchors = GetTableAnchorsSelector();
        }

        private static string GetTableAnchorsSelector()
        {
            string attributeConditions = new SelectorAttributesBuilder().Class("navbox-list", AttributeSearchCriteria.Contains).Build();

            var sb = new StringBuilder();

            sb.Append($"{Html.Tags.TableDataCell}")
                .Append($"{attributeConditions}")
                .Append(" ")
                .Append(Html.Tags.Anchor);

            return sb.ToString();
        }
    }
}
