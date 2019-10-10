using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Api.Repository;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : Controller
	{
		private readonly IProjectsRepository _repo;
        public ProjectsController(IProjectsRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAllProjects() => Ok(_repo.GetAll());

        [HttpGet]
		[Route("{id}")]
		public IActionResult GetProject(Guid id)
		{
			var project = _repo.GetById(id);
			if(project == null) return NotFound("Project was not found");
			return Ok(project);
		}
	}
}
