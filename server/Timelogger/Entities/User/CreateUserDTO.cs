using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class CreateUserDTO
	{
        [Required]
        [UniqueUserName]
        [MinLength(5, ErrorMessage="User name must have at least 5 characters")]
		public string Name { get; set; }
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }
		public string PathToAvatar { get; set;}
	}
}
