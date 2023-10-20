using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    public class Pagination<T> where T : class
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public bool Prev { get; private set; }
        public bool Next { get; private set; }
        public IQueryable<T> PagedData { get; private set; }

        public Pagination(IQueryable<T> data, int page = 1, int per_page = 12, int limit = 3)
        {
            int totalPages = (int)Math.Ceiling(data.Count() / (decimal)per_page);
            Start = page - limit > 1 ? page - limit : 1;
            End = page + limit < totalPages ? page + limit : totalPages;
            Prev = page != 1;
            Next = page != totalPages;
            PagedData = data.Skip(per_page * (page - 1)).Take(per_page);
            Page = page;
            PerPage = per_page;



        }

    }
}
