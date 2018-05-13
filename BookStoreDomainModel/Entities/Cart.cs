using System.Linq;
using System.Collections.Generic;

namespace BookStoreDomainModel.Entities
{
    public class Cart
    {
        // A list of books
        private List<Item> goodsList = new List<Item>();

        public void AddItem(Book book, int count)
        {
            Item viewModel = goodsList.Where(model => model.Book.Id == book.Id).FirstOrDefault();
            if(viewModel == null)
            {
                goodsList.Add(new Item()
                {
                    Book = book,
                    Quantity = count
                });
            }
            else
            {
                viewModel.Quantity += count;
            }
        }

        public void RemoveItem(Book book)
        {
            goodsList.RemoveAll(goods => goods.Book.Id == book.Id);
        }

        public decimal CalculateTotalPrice()
        {
            return goodsList.Sum(goods => goods.Book.Price * goods.Quantity);
        }

        public void ClearItems()
        {
            goodsList.Clear();
        }

        public IEnumerable<Item> Goods
        {
            get
            {
                return goodsList;
            }
        }

    }
}
