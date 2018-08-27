using LibrarySystem.Application.ViewModels;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Application.Parsers
{
    public class ModelToModelView
    {
        public static BookView BookToBookView(Book book)
        {
            BookView viewObject = new BookView();
            viewObject.BookId = book.BookId;
            viewObject.Description = book.Description;
            viewObject.Edition = book.Edition;
            viewObject.Name = book.Name;
            viewObject.PublicationDate = book.PublicationDate;
            viewObject.WriterName = book.WriterName;

            return viewObject;
        }
        public static List<BookView> parseAllBooksToBookView(IEnumerable<Book> books)
        {
            List<BookView> viewObjects = new List<BookView>();
            foreach (Book book in books)
                viewObjects.Add(BookToBookView(book));

            return viewObjects;
        }
    }
}