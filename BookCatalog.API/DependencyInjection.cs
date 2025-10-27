using BookCatalog.Application.Interfaces;
using BookCatalog.Application.Services;
using BookCatalog.Infrastructure.Repositories;

namespace BookCatalog.API
{
    public static class DependencyInjection
    {
        public static void AddBookCatalogServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, InMemoryBookRepository>();
            services.AddScoped<IAuthorRepository, InMemoryAuthorRepository>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
