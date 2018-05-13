using System.Collections.Generic;
using BookStoreDomainModel.Abstract;
using BookStoreDomainModel.Entities;

namespace BookStoreDomainModel.Concrete
{
    public class BookRepository : IBookRepository
    {
        // Create a context to get data from a repository
        EFdbContext context = new EFdbContext();

        // Return books from db
        public IEnumerable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }
    }
}
