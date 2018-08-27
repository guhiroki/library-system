using LibrarySystem.Infrastructure;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Mappers;

namespace LibrarySystem.Domain.Repository.Implementation
{
    public class BookRepository : GenericFactory<Book, BookMapper>, IBookRepository
    {
    }
}
