using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class ActivityUpdateDTO
	{
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage="Activity name must have at least 5 characters")]
		public string Name { get; set; }
        public string Description { get; set; }
	}
}
