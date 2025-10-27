
namespace BookCatalog.Application.Common.Validator
{
    public class ValidatorResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();

        public static ValidatorResult IsInvalidRequest(List<string> errors) => new ValidatorResult()
        {
            IsValid = false,
            Errors = errors
        };

        public static ValidatorResult IsValidRequest() => new ValidatorResult()
        {
            IsValid = true
        };

    }
}
