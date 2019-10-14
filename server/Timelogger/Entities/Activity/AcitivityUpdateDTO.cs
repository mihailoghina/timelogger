using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class ActivityUpdateDTO
	{
        [Required]
        [MinLength(5, ErrorMessage="Activity name must have at least 5 characters")]
		public string Name { get; set; }
        public string Description { get; set; }
		[Required]
        [Range(30, Int32.MaxValue, ErrorMessage="Minimum logged time must exceed 30 minutes")]
        public int LoggedMinutes { get; set; }
	}
}
