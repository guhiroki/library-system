using Infrastructure.Entity;
using LibrarySystem.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibrarySystem.Domain.Mappers
{
    public class BookMapper : BaseEntity
    {
        public BookMapper() : base() 
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
