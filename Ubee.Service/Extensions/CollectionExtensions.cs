using Ubee.Domain.Configurations;

namespace Ubee.Service.Extensions;

public static class CollectionExtensions
{
    public static IQueryable<TResult> ToPagedList<TResult>(this IQueryable<TResult> source, PaginationParams @params)
    {
        return source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
    }
}
