using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Entity
{
    public class BaseEntity : DbContext
    {
        public BaseEntity() 
            : base("LibrarySystem")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
