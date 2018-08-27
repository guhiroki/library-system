

using LibrarySystem.Application.ViewModels;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Parsers
{
    public class ModelViewToModel
    {
        public static Book ViewBookToBook(BookView book)
        {
            Book dataObject = new Book();
            dataObject.BookId = book.BookId;
            dataObject.Description = book.Description;
            dataObject.Edition = book.Edition;
            dataObject.Name = book.Name;
            dataObject.PublicationDate = book.PublicationDate;
            dataObject.WriterName = book.WriterName;

            return dataObject;
        }
    }
}