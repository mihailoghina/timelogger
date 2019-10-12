using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class CreateProjectDTO
	{
		[Required]
		[MinLength(5, ErrorMessage="Project name must have at least 5 characters")]
		public string Name { get; set; }
		[Required]
		public Guid CreatedBy { get; set; }
		[Required]
		public DateTime DeadLineDate { get; set; }
	}
}
