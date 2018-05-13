using System.Linq;
using BookStoreWeb.Models;
using System.Web.Mvc;
using BookStoreDomainModel.Abstract;

namespace BookStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository bookRepository = null;
        private int pageSize = 4;

        // Get book using di
        public HomeController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // Show a list of books by category for a specified page
        public ViewResult Index(string category, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel()
            {
                Books = bookRepository.Books.Where(book => category == null || book.Category  == category)
                .OrderBy(book => book.Id).Skip((page - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo()
                {
                    CurrentPage = page,
                    ItemsCount = category == null ? bookRepository.Books.Count(): bookRepository.Books.Where(x => x.Category == category).Count(),
                    ItemsPerPage = pageSize
                },
                Category = category
            };
            return View(model);
        }
    }
}