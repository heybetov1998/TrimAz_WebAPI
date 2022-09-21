using System.Linq.Expressions;

namespace Extensions
{
    public static class LinqExtensions
    {
        public static IOrderedEnumerable<TSource> OrderByDirection<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            bool descending)
        {
            return descending ?
                source.OrderByDescending(keySelector) :
                source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> OrderByDirection<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }
    }
}
