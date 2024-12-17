using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp;

namespace Syrna.AuditLogging;

public static class LinqExt
{
    public static IQueryable<T> OrderByIf<T>(this IQueryable<T> query, bool condition, string sorting)
    {
        Check.NotNull(query, nameof(query));
        return condition
            ? DynamicQueryableExtensions.OrderBy(query, sorting)
            : query;
    }
}