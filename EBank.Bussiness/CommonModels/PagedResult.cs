using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Bussiness.CommonModels
{
    public class PagedResult<T> where T : class
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalNumberOfPages { get; set; }

        public int TotalNumberOfRecords { get; set; }

        public IEnumerable<T> Results { get; set; }
    }

    public class PagingRequest
    {
        public int? Page { get; set; } = null;
        public int? PageSize { get; set; } = null;
        public string KeySearch { get; set; } = string.Empty;
        public SortOrder SortType { get; set; } = SortOrder.None;
        public string ColName { get; set; } = "Id";
    }
}
