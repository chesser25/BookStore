using BookStoreDomainModel.Entities;

namespace BookStoreWeb.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUri { get; set; }
    }
}