
using BookCatalog.Application.Common.Validator;
using BookCatalog.Application.DTOs;

namespace BookCatalog.Application.Interfaces
{
    public interface IValidator
    {
        public bool IsValidTitle(string title);
        public bool IsValidPublicationYear(int year);
        public bool AuthorIdExists(int ID);

        public Task<ValidatorResult> ValidateRequest(CreateBookDto request);
    }
}
