using LibrarySystem.Application.Parsers;
using LibrarySystem.Application.ViewModels;
using LibrarySystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibrarySystem.Application.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private BookService bookService = new BookService();

        public BookController() { }
        // GET: api/Book
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            List<BookView> books = new List<BookView>();
            try
            {
                books = ModelToModelView.parseAllBooksToBookView(bookService.GetAll());
                response = Request.CreateResponse(HttpStatusCode.OK, books);
            }
            catch (Exception e) {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // POST: api/Book
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BookView book)
        {
            HttpResponseMessage response = null;

            try
            {
                if (book.BookId == null || book.BookId == 0)
                {
                    bookService.Add(ModelViewToModel.ViewBookToBook(book));
                }
                else
                {
                    bookService.Update(ModelViewToModel.ViewBookToBook(book));
                }

                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // DELETE: api/Book/5
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]BookView value)
        {
            HttpResponseMessage response = null;

            try
            {
                bookService.Delete(ModelViewToModel.ViewBookToBook(value));
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }
    }
}
