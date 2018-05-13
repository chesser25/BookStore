using MySql.Data.Entity;
using System.Data.Entity;
using BookStoreDomainModel.Entities;

namespace BookStoreDomainModel.Concrete
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EFdbContext: DbContext
    {
        public EFdbContext() : base("DbContext") { }
        public DbSet<Book> Books { get; set; } 
    }
}
