using System.Web.Mvc;
using BookStoreDomainModel.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWeb.Controllers
{
    public class MenuController : Controller
    {
        private IBookRepository bookRepository = null;

        // Get book repository from di
        public MenuController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // Create a side menu to allow users' category selection
        public PartialViewResult ShowSideMenu(string category)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = bookRepository.Books.Select(book => book.Category).Distinct().OrderBy(book => book);
            return PartialView("SideMenu", categories);
        }
    }
}