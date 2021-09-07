namespace CodWeaponsRandomizer.Core
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            return enumerable.OrderBy(i => random.Next());
        }
    }
}
