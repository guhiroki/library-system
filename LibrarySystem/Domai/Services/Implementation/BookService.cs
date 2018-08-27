using System;
using System.Collections.Generic;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Repository;
using LibrarySystem.Domain.Repository.Implementation;

namespace LibrarySystem.Domain.Services
{
    public class BookService : IBookService
    {
        private static BookRepository _repository = new BookRepository();
        public BookService()
        {
        }

        public void Add(Book book)
        {
            _repository.Add(book);
        }

        public void Delete(Book book)
        {
            _repository.Delete(book.BookId);
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Book book)
        {
            _repository.Update(book);
        }
    }
}
