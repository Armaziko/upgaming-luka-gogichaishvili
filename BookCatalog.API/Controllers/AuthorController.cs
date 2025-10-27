using BookCatalog.Application.Interfaces;

namespace BookCatalog.API.Controllers
{
    public static class AuthorController
    {
        public static void MapAuthorEndpoints(this WebApplication app)
        {

            app.MapGet("/api/authors/{id}/books", async (IBookService bookService, int id) =>
            {
                var attemptGetBooksByAuthor = await bookService.GetBooksByAuthor(id);

                return Results.Json(
                    attemptGetBooksByAuthor.IsSuccess ? attemptGetBooksByAuthor.Books : attemptGetBooksByAuthor.Error,
                    statusCode: (int)attemptGetBooksByAuthor.StatusCode
                    );
            });

            //BONUS TASK (parameter - id) (returns name of the author with nested list of his books)
            app.MapGet("/api/authors/{id}", async (int id, IBookService bookService) =>
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
