using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
	public class Activity
	{
		public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
		public int LoggedMinutes { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
