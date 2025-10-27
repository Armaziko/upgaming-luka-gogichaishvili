

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

                if (!attemptGetAllBooks.IsSuccess)
                    return Results.BadRequest("Failed to get books. " + attemptGetAllBooks.Error);

                return Results.Ok(attemptGetAllBooks.Books);
            });

            app.MapGet("/api/authors/{id}/books", async (IBookService bookService, int id) =>
            {
                var attemptGetBooksByAuthor = await bookService.GetBooksByAuthor(id);
                if (!attemptGetBooksByAuthor.IsSuccess)
                    return Results.NotFound("Failed to get books. " + attemptGetBooksByAuthor.Error);

                return Results.Ok(attemptGetBooksByAuthor.Books);
            });

            app.MapPost("/api/books", async (CreateBookDto createBookDto, IBookService bookService) =>
            {
                var attemptAddBook = await bookService.AddBookDto(createBookDto);
                if (!attemptAddBook.IsSuccess)
                    return Results.BadRequest("Failed to add the book. " + attemptAddBook.Error);
                if (attemptAddBook.Book is null)
                    return Results.BadRequest("Failed to add the book. " + attemptAddBook.Error);

                var newBookId = attemptAddBook.Book.ID;
                return Results.Created($"/api/books/{newBookId}", attemptAddBook.Book);
            });

        }
    }
}
