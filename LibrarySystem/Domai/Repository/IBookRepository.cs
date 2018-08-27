using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Factory;

namespace LibrarySystem.Domain.Repository
{
    public interface IBookRepository : IGenericFactory<Book>
    {
    }
}
