using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class RecordUpdateDTO
	{   
        [Required]
        public Guid ActivityId { get; set; }
        [Required]
        [MinLength(30, ErrorMessage="Minimum logged time must exceed 30 minutes")]
        public int LoggedMinutes { get; set; }
        [Required]
        [MinLength(5, ErrorMessage="Minimum record length should be 5 characters")]
		public string Name { get; set; }
        public string Description { get; set; }
	}
}
