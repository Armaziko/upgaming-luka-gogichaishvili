
using BookCatalog.Application.Common.BookService;
using BookCatalog.Application.DTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IValidator _validator;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IValidator validator)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<AddBookResult> AddBookDto(CreateBookDto createBookDto)
        {

            var CheckIfValidDTO = _validator.ValidateRequest(createBookDto);
            if (!CheckIfValidDTO.Result.IsValid)
                return AddBookResult.InvalidDTO(CheckIfValidDTO.Result.Errors);

            var attemptGetBooks = await _bookRepository.GetAllBooks(); //They are needed to check if an id exists before adding a new book
            //Generating a new integer ID that doesn't already exist.
            int newId = 1; 
            if(attemptGetBooks.Count != 0)
            {
                newId = attemptGetBooks.Max(b => b.ID) + 1;
            }

            //Creating a new book instance
            Book newBook = new Book()
            {
                ID = newId,
                AuthorID = createBookDto.AuthorId,
                PublicationYear = createBookDto.PublicationYear,
                Title = createBookDto.Title
            };

            var addBook = await _bookRepository.AddBook(newBook);

            return AddBookResult.SuccessfullyAddedBook(addBook);
        }

        public async Task<BookServiceResult> GetAllBooksAsync() 
        {
            //To get list of book dtos, the simplest way is to just fetch entire lists as they are small.
            List<BookDto> booksToReturn = new();

            List<Book> books = await _bookRepository.GetAllBooks();
            List<Author> authors = await _authorRepository.GetAllAuthors();

            foreach (var book in books)
            {
                var authorName = authors.FirstOrDefault(a => a.ID == book.AuthorID)?.Name;
                if (string.IsNullOrWhiteSpace(authorName))
                {
                    continue; //Just skips over the nameless author to return other book DTOs.
                }
                else
                {
                    BookDto newBookDto = new BookDto()
                    {
                        ID = book.ID,
                        AuthorName = authorName,
                        Title = book.Title,
                        PublicationYear = book.PublicationYear
                    };
                    booksToReturn.Add(newBookDto);
                }
            };

            if (booksToReturn.Count == 0)
                return BookServiceResult.NoBooksFound();

            return BookServiceResult.SuccessfullyFetchedBooks(booksToReturn);

        }

        public async Task<BookServiceResult> GetBooksByAuthor(int authorId)
        {
            //As the lists are small, the simplest way of getting all books by author is just fetch all the lists and work on them

            List<BookDto> booksToReturn = new();

            List<Author> authors = await _authorRepository.GetAllAuthors();
            List<Book> books = await _bookRepository.GetAllBooks();

            foreach (var book in books)
            {
                if (book.AuthorID == authorId)
                {
                    var authorName = authors.FirstOrDefault(a => a.ID == authorId)?.Name;
                    if (string.IsNullOrWhiteSpace(authorName))
                        continue; //Skip over the nameless author
                    else
                    {
                        BookDto newBookDto = new BookDto()
                        {
                            ID = book.ID,
                            AuthorName = authorName,
                            Title = book.Title,
                            PublicationYear = book.PublicationYear
                        };
                        booksToReturn.Add(newBookDto);
                    }
                }
            }

            if (booksToReturn.Count == 0) 
                return BookServiceResult.NoBooksFound();

            return BookServiceResult.SuccessfullyFetchedBooks(booksToReturn);

        }
    }
}
