using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Domain.Services
{
    public interface IBookService
    {
        void Add(Book book);
        
        void Delete(Book book);

        List<Book> GetAll();

        void Update(Book book);
    }
}
