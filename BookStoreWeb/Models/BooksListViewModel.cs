using BookStoreDomainModel.Entities;
using System.Collections.Generic;

namespace BookStoreWeb.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
        public string Category { get; set; }
    }
}