
using BookCatalog.Application.Common.Validator;
using BookCatalog.Application.DTOs;
using BookCatalog.Application.Interfaces;

namespace BookCatalog.Application.Validators
{
    public class CreateBookValidators : IValidator
    {
        private readonly IAuthorRepository _authorRepository;
        public CreateBookValidators(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }
        public bool IsValidTitle(string title)
        {
            return !string.IsNullOrEmpty(title));
        }
        public bool IsValidPublicationYear(int year)
        {
            return year <= DateTime.Now.Year;
        }

        public bool AuthorIdExists(int ID)
        {
            var attemptGetAuthors = _authorRepository.GetAllAuthors();
            foreach(var author in attemptGetAuthors.Result)
            {
                if (author.ID == ID) return true;
            }
            return false;
        }

        public Task<ValidatorResult> ValidateRequest(CreateBookDto request)
        {
            bool isValid = true;
            List<string> errors = new();
            if (!IsValidTitle(request.Title))
            {
                isValid = false;
                errors.Add($"Title is invalid. It can't be null or empty. \n");
            }
            if (!IsValidPublicationYear(request.PublicationYear))
            {
                isValid = false;
                errors.Add($"Publication field is invalid. It can't be in the future.  \n");
            }
            if (!AuthorIdExists(request.AuthorId))
            {
                isValid = false;
                errors.Add($"Author ID is invalid. Author with the given ID doesn't exist.  \n");
            }

            if (isValid)
                return Task.FromResult(ValidatorResult.IsInvalidRequest(errors));

            return Task.FromResult(ValidatorResult.IsValidRequest());

        }

        

    }
}
