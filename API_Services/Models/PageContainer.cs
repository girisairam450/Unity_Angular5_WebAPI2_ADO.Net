using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class PageContainer<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int ItemsCount => Items?.Count() ?? 0;

        public int TotalCount { get; set; }
    }
}