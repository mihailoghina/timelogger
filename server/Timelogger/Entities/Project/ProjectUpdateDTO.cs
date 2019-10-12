using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class ProjectUpdateDTO
	{
        [Required]
		[MinLength(5, ErrorMessage="Project name must have at least 5 characters")]
		public string Name { get; set; }
		public bool IsComplete { get; set; }
		public DateTime DeadLineDate { get; set; }
	}
}
