using System.Net;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Common.BookService
{
    public class AddBookResult : Result
    {
        public Book? Book { get; set; }

        public static AddBookResult SuccessfullyAddedBook(Book book) => new AddBookResult()
        {
            IsSuccess = true,
            Message = "Successfully added the book. ",
            Book = book,
            StatusCode = HttpStatusCode.Created
        };
    }
}
