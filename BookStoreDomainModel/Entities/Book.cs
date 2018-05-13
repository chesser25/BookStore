using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreDomainModel.Entities
{
    [Table("BooksInfo")]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
