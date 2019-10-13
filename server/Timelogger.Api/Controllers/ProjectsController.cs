using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Api.Repository;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : Controller
	{
		private readonly IProjectsRepository _repo;
        public ProjectsController(IProjectsRepository repo) 
		{
			_repo = repo;
		} 

        [HttpGet(Name = nameof(GetAllProjects))]
        public IActionResult GetAllProjects([FromQuery] bool includeChildren) 
		{
			return Ok(_repo.GetAll(includeChildren));
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetProject))]
		public IActionResult GetProject(Guid id, [FromQuery] bool includeChildren)
		{
			var project = _repo.GetById(id, includeChildren);

			if(project == null) 
			{
				return NotFound("Project was not found");
			}
						
			return Ok(project);
		}

		[HttpPost(Name = nameof(CreateProject))]
		public IActionResult CreateProject([FromBody] CreateProjectDTO createProjectDTO)
		{
			if(createProjectDTO == null) 
			{
				return BadRequest();
			}

			if(!ModelState.IsValid)
			{
				var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .ToList();

				return BadRequest(errors);
			}

			var project = new Project
			{
				Id = Guid.NewGuid(),
				Name = createProjectDTO.Name,
				CreatedBy = createProjectDTO.CreatedBy,
				DeadLineDate = createProjectDTO.DeadLineDate,
				CreationDate = DateTime.Now
			};		

			var createdProject = _repo.Add(project);

			if(createdProject == null)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to add project"
				};					
			}

			return CreatedAtAction(nameof(CreateProject), new { id = createdProject.Id }, createdProject);			
		}

		[HttpDelete]
		[Route("{id:Guid}", Name = nameof(DeleteProject))]
		public IActionResult DeleteProject(Guid id)
		{
			var project = _repo.GetById(id);

			if(project == null) 
			{
				return BadRequest("Project has not been found");
			}

			if(!_repo.Delete(project))
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to delete project. Project {id} was not deleted"
				};
			}
			
			return Ok();
		}

		[HttpPut]
        [Route("{id:Guid}", Name = nameof(UpdateProject))]
        public IActionResult UpdateProject(Guid id, [FromBody]ProjectUpdateDTO projectUpdateDTO)
        {
            if (projectUpdateDTO == null)
            {
                return BadRequest();
            }

			var project = _repo.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

			if(!ModelState.IsValid)
			{
				var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .ToList();

				return BadRequest(errors);
			}

			//prevent closed projects to be opened again because all activity records will look for this flag
			if(project.IsComplete == true && projectUpdateDTO.IsComplete == false) 
			{
				return BadRequest("Completed project cannot be modified");
			}
			else
			{
				project.Name = projectUpdateDTO.Name;
				project.IsComplete = projectUpdateDTO.IsComplete;
				project.DeadLineDate = projectUpdateDTO.DeadLineDate;

				if(!_repo.Update(project))
				{
					return new ContentResult
					{
						StatusCode = 500,
						Content = $"Error occured while attempting to update project. Project {project.Id} was not deleted"
					};	
				}

				return Ok(project);
			}           
        }
	}
}
