using System;

namespace BookStoreWeb.Models
{
    public class PageInfo
    {
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount
        {
            get
            {
                return (int)Math.Ceiling((decimal)ItemsCount / ItemsPerPage);
            }
        }
    }
}