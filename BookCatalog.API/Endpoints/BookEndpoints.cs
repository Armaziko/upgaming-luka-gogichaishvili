

using BookCatalog.Application.DTOs;
using BookCatalog.Application.Interfaces;

namespace BookCatalog.API.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this WebApplication app)
        {



            app.MapGet("/api/books", async (IBookService bookService) =>
            {
                var attemptGetAllBooks = await bookService.GetAllBooksAsync();

                return Results.Json(
                    attemptGetAllBooks.IsSuccess ? attemptGetAllBooks.Books : new { error = attemptGetAllBooks.Error },
                    statusCode: (int)attemptGetAllBooks.StatusCode);
            });

            app.MapGet("/api/authors/{id}/books", async (IBookService bookService, int id) =>
            {
                var attemptGetBooksByAuthor = await bookService.GetBooksByAuthor(id);

                return Results.Json(
                    attemptGetBooksByAuthor.IsSuccess ? attemptGetBooksByAuthor.Books : attemptGetBooksByAuthor.Error,
                    statusCode: (int)attemptGetBooksByAuthor.StatusCode
                    );
            });

            app.MapPost("/api/books", async (CreateBookDto createBookDto, IBookService bookService) =>
            {
                var attemptAddBook = await bookService.AddBookDto(createBookDto);
                if (attemptAddBook.Book is null)
                    return Results.Problem("Failed to add the book. " + attemptAddBook.Error);


                if(attemptAddBook.IsSuccess && (int)attemptAddBook.StatusCode == 201)
                {
                    var newBookId = attemptAddBook.Book.ID;
                    return Results.Created($"/api/books/{newBookId}", attemptAddBook.Book); ;
                }

                return Results.Json(
                    attemptAddBook.IsSuccess ? attemptAddBook.Book : attemptAddBook.Error,
                    statusCode: (int) attemptAddBook.StatusCode
                    );
            });

            //BONUS TASK (parameter - id) (returns name of the author with nested list of his books)
            app.MapPost("/api/authors/{id}", async (int id, IBookService bookService) =>
            {
                var attemptGetAuthorDetails = await bookService.GetAuthorDetails(id);

                return Results.Json(
                    attemptGetAuthorDetails.IsSuccess ? attemptGetAuthorDetails.AuthorDetails : attemptGetAuthorDetails.Error,
                    statusCode: (int)attemptGetAuthorDetails.StatusCode
                    );
            });

        }
    }
}
