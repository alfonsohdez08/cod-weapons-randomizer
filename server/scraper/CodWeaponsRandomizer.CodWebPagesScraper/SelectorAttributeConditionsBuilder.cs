namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class SelectorAttributeConditionsBuilder
    {
        private const string ClassAttribute = "class";
        private const string TitleAttribute = "title";
        private const string DataSourceAttribute = "data-source";

        private readonly Dictionary<string, string> _conditions;
        private SelectorAttributeConditionsBuilder() => _conditions = new Dictionary<string, string>();

        public SelectorAttributeConditionsBuilder Class(string cssClass)
        {
            _conditions[ClassAttribute] = cssClass;
            return this;
        }

        public SelectorAttributeConditionsBuilder Title(string title)
        {
            _conditions[TitleAttribute] = title;
            return this;
        }

        public SelectorAttributeConditionsBuilder DataSource(string dataSource)
        {
            _conditions[DataSourceAttribute] = dataSource;
            return this;
        }

        public string Build() => string.Join("", _conditions.Select(kv => $"[{kv.Key}=\"{kv.Value}\"]"));

        public static SelectorAttributeConditionsBuilder Create() => new SelectorAttributeConditionsBuilder();
    }
}
