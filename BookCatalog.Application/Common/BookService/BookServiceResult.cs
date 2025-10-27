

using BookCatalog.Application.DTOs;
using System.Net;

namespace BookCatalog.Application.Common.BookService
{
    public class BookServiceResult : Result
    {
        public List<BookDto> Books { get; set; }
        public BookServiceResult(List<BookDto> books) // Constructor ensures that the list of books is never null
        {
            Books = books;
        }

        public static BookServiceResult SuccessfullyFetchedBooks(List<BookDto> books) => new BookServiceResult(books)
        {
            IsSuccess = true,
            Message = "Needed books were found.",
            StatusCode = HttpStatusCode.OK
        };

        public static BookServiceResult NoBooksFound() => new BookServiceResult(new List<BookDto>())
        {
            IsSuccess = false,
            Error = "Could not find any books.",
            StatusCode = HttpStatusCode.NotFound
        };

    }
}
