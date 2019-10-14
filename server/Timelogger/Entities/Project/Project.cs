using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
	public class Project
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int LoggedMinutes { get; set; }
		public bool IsComplete { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime DeadLineDate { get; set; }
	}
}
