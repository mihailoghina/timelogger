using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApiContext)validationContext.GetService(typeof(ApiContext));

            var entity = _context.Users.SingleOrDefault(_ => _.Name == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string userName)
        {
            return $"User name: {userName} is already in use";
        }
    }
}