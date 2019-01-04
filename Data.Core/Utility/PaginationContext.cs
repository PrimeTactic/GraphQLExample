using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Utility
{
    public class PaginationContext
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalItems { get; set; }

        public string OrderByProperty { get; set; }
    }
}
