using System.Collections.Generic;
using BookStoreDomainModel.Entities;

namespace BookStoreDomainModel.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
    }
}
