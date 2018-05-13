using BookStoreDomainModel.Abstract;
using System.Web.Mvc;
using System.Linq;
using BookStoreDomainModel.Entities;
using BookStoreWeb.Models;

namespace BookStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository bookRepository = null;
        private IOrderProcess orderProcess = null;

        // Get book repository and orderProcess from di(Dependency Injection)
        public CartController(IBookRepository bookRepository, IOrderProcess orderProcess)
        {
            this.bookRepository = bookRepository;
            this.orderProcess = orderProcess;
        }

        // Show cart
        public ViewResult Index(Cart cart, string returnUri)
        {
            return View(new CartViewModel()
            {
                Cart = cart,
                ReturnUri = returnUri
            });
        }

        public RedirectToRouteResult AddItemToCart(Cart cart, int id, string returnUri)
        {
            Book book = bookRepository.Books.FirstOrDefault(item => item.Id == id);
            if(book != null)
            {
                cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", new {returnUri });
        }

        public RedirectToRouteResult RemoveItemFromCart(Cart cart, int bookId, string returnUri)
        {
            Book book = bookRepository.Books.Where(item => item.Id == bookId).FirstOrDefault();
            if(book != null)
            {
                cart.RemoveItem(book);
            }
            return RedirectToAction("Index", new {returnUri });
        }

        // Link for a widget to be able to look into the cart
        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }

        // Show Order View
        public ViewResult MakeOrder(Cart cart)
        {
            return View(new Order());
        }

        // Create an order
        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order)
        {
            if(cart.Goods.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if(ModelState.IsValid)
            {
                orderProcess.Order(cart, order);
                cart.ClearItems();
                return View("ShoppingCompleted");
            }
            else
            {
                return View("MakeOrder", order);
            }
        }
    }
}