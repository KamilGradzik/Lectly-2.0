using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Common
{
    public class PagedResult<T>
    {
        IReadOnlyList<T> Items { get; }
        int Page { get; }
        int PageSize { get; }
        int TotalCount { get; }

        public PagedResult(IReadOnlyList<T> items, int page, int pageSize, int totalCount) {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}