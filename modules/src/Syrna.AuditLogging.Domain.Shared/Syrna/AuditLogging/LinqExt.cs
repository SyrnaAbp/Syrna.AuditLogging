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
            ? query.OrderBy(sorting)
            : query;
    }
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, string filtering)
    {
        Check.NotNull(query, nameof(query));
        return condition
            ? query.Where(filtering)
            : query;
    }
}