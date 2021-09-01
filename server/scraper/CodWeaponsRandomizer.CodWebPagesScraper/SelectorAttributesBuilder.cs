namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    enum AttributeSearchCriteria
    {
        Exact = 0,
        Contains
    }

    class SelectorAttributesBuilder
    {
        private const string ClassAttribute = "class";
        private const string TitleAttribute = "title";
        private const string DataSourceAttribute = "data-source";

        private readonly Dictionary<string, (string, AttributeSearchCriteria)> _attributes;
        public SelectorAttributesBuilder() => _attributes = new Dictionary<string, (string, AttributeSearchCriteria)>();

        private static string ParseSearchCriteria(AttributeSearchCriteria searchCriteria)
        {
            switch (searchCriteria)
            {
                case AttributeSearchCriteria.Contains:
                    return "*";
                default:
                    return "";
            }
        }

        private SelectorAttributesBuilder AddAttribute(string attribute, string value, AttributeSearchCriteria searchCriteria)
        {
            _attributes[attribute] = (value, searchCriteria);
            return this;
        }

        public SelectorAttributesBuilder Class(string cssClass, AttributeSearchCriteria searchCriteria = AttributeSearchCriteria.Exact)
            => AddAttribute(ClassAttribute, cssClass, searchCriteria);

        public SelectorAttributesBuilder Title(string title, AttributeSearchCriteria searchCriteria = AttributeSearchCriteria.Exact)
            => AddAttribute(TitleAttribute, title, searchCriteria);

        public SelectorAttributesBuilder DataSource(string dataSource, AttributeSearchCriteria searchCriteria = AttributeSearchCriteria.Exact)
            => AddAttribute(DataSourceAttribute, dataSource, searchCriteria);

        public string Build()
        {
            try
            {
                return string.Join("", _attributes.Select(kv => $"[{kv.Key}{ParseSearchCriteria(kv.Value.Item2)}=\"{kv.Value.Item1}\"]"));
            }
            finally
            {
                _attributes.Clear();
            }
        }
    }
}
