

using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Common.BookService
{
    public class GetAuthorDetailsResult : Result
    {
        public AuthorDetailsDto AuthorDetails { get; set; }
        public static GetAuthorDetailsResult SuccessfullyFoundAuthorDetails(List<Book> authorBooks, string authorName) => new GetAuthorDetailsResult()
        {
            IsSuccess = true,
            Message = "Successfully found the detailed information about the author, including his books. ",
            AuthorDetails = new AuthorDetailsDto() { AuthorBooks = authorBooks, AuthorName = authorName},
            StatusCode = System.Net.HttpStatusCode.OK
        };

        public static GetAuthorDetailsResult AuthorDoesNotExist() => new GetAuthorDetailsResult()
        {
            IsSuccess = false,
            Error = "Author with the given ID doesn't exist.",
            StatusCode = System.Net.HttpStatusCode.NotFound
        };

        public static GetAuthorDetailsResult AuthorNameIsEmpty() => new GetAuthorDetailsResult()
        {
            IsSuccess = false,
            Error = "Author with the given ID has no name.",
            StatusCode = System.Net.HttpStatusCode.BadRequest
        };

    }
}
