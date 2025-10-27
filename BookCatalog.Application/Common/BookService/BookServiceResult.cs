

using BookCatalog.Application.DTOs;

namespace BookCatalog.Application.Common.BookService
{
    public class BookServiceResult : Result
    {
        List<BookDto> Books { get; set; }

        public BookServiceResult(List<BookDto> books) // Constructor ensures that the list of books is never null
        {
            Books = books;
        }

        public static BookServiceResult AllBooksFound(List<BookDto> books) => new BookServiceResult(books)
        {
            IsSuccess = true,
            Message = "All books were found."
        };

    }
}
