using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class PageContainerCombined<T> : PageContainer<T>
    {
        public int UnreadCount { get; set; }

        public int FavoriteCount { get; set; }
    }
}