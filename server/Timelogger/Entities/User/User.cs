using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
	public class User
	{
		public Guid Id { get; set; }
        public string Email { get; set; }
		public string Name { get; set; }
		public string PathToAvatar { get; set;}
		public DateTime CreationDate { get; set; }
		public IEnumerable<Project> UserProjects { get; set; }
	}
}
