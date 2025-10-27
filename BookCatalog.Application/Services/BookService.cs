
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

            var attemptGetBooks = await _bookRepository.GetAllBooks();

            var newBookId = await _bookRepository.GenerateNewId();

            Book newBook = new Book()
            {
                ID = newBookId,
                AuthorID = createBookDto.AuthorId,
                PublicationYear = createBookDto.PublicationYear,
                Title = createBookDto.Title
            };

            var addBook = await _bookRepository.AddBook(newBook);

            return AddBookResult.SuccessfullyAddedBook(addBook);
        }

        public async Task<BookServiceResult> GetAllBooksAsync() 
        {
            //To get list of book dtos, the simplest way is to just fetch entire lists as they are small and just iterate over lists.
            List<BookDto> booksToReturn = new();

            List<Book> books = await _bookRepository.GetAllBooks();
            List<Author> authors = await _authorRepository.GetAllAuthors();

            foreach (var book in books)
            {
                var author = authors.FirstOrDefault(a => a.ID == book.AuthorID);
                if (author is null)
                    continue;

                var authorName = author.Name;
                
                if (string.IsNullOrWhiteSpace(authorName))
                {
                    continue; //Just skips over the nameless author instead of throwing or breaking in order to return other book DTOs.
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

        public async Task<GetAuthorDetailsResult> GetAuthorDetails(int AuthorId)
        {
            //GO OVER AUTHORS TO SEE IF HE EXISTS. IF SO STORE HIS NAME  IF NOT RETURN AUTHOR DOES NOT EXIST
            //THAN GO OVER BOOKS AND COLLECT ALL THE BOOKS WITH HIS ID IN A LIST.

            var attemptGetAuthors = await _authorRepository.GetAllAuthors();

            var author = attemptGetAuthors.FirstOrDefault(author => author.ID == AuthorId);
            if (author is null)
                return GetAuthorDetailsResult.AuthorDoesNotExist();

            var authorName = author.Name;
            if (string.IsNullOrWhiteSpace(authorName))
                return GetAuthorDetailsResult.AuthorNameIsEmpty();

            var attemptGetBooks = await _bookRepository.GetAllBooks();

            var filteredBooks = attemptGetBooks.Where(book => book.AuthorID == AuthorId).ToList();

            return GetAuthorDetailsResult.SuccessfullyFoundAuthorDetails(filteredBooks, authorName);
        }

        public async Task<BookServiceResult> GetBooksByAuthor(int authorId)
        {
            //As the lists are small, the simplest way of getting all books by author is just fetch all the lists and work on them

            List<BookDto> booksToReturn = new();

            List<Author> authors = await _authorRepository.GetAllAuthors();
            List<Book> books = await _bookRepository.GetAllBooks();

            foreach (var book in books)
            {
                if (book.AuthorID != authorId)
                    continue;
                
                var author = authors.FirstOrDefault(a => a.ID == authorId);
                if (author is null)//Should log this as this is wrong, but for simplicity I left it like this
                    continue;

                var authorName = author.Name;
                if (string.IsNullOrWhiteSpace(authorName))
                    continue;
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

            if (booksToReturn.Count == 0) 
                return BookServiceResult.NoBooksFound();

            return BookServiceResult.SuccessfullyFetchedBooks(booksToReturn);

        }
    }
}
