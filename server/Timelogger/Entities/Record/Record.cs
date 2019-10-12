using System;

namespace Timelogger.Entities
{
	public class Record
	{
		public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public int LoggedMinutes { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
