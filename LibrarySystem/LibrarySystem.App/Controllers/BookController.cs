﻿using LibrarySystem.Application.Parsers;
using LibrarySystem.Application.ViewModels;
using LibrarySystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibrarySystem.Application.Controllers
{
    public class BookController : ApiController
    {
        private IBookService _iBookService;

        public BookController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        // GET: api/Book
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            List<BookView> books = new List<BookView>();
            try
            {
                books = ModelToModelView.parseAllBooksToBookView(_iBookService.GetAll());
                response = Request.CreateResponse(HttpStatusCode.OK, books);
            }
            catch (Exception e) {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // POST: api/Book
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BookView value)
        {
            HttpResponseMessage response = null;

            try
            {
                _iBookService.Add(ModelViewToModel.ViewBookToBook(value));
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
                _iBookService.Delete(ModelViewToModel.ViewBookToBook(value));
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
