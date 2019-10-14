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
		private readonly IRepositoryWrapper _repositoryWrapper;
        public ProjectsController(IRepositoryWrapper repositoryWrapper) 
		{
			_repositoryWrapper = repositoryWrapper;
		} 

        [HttpGet(Name = nameof(GetAllProjects))]
        public IActionResult GetAllProjects([FromQuery] bool includeTime = false) 
		{
			var projects = _repositoryWrapper.ProjectRepository.GetAll();

			if(includeTime)
			{
				projects = projects.Select( _ => { _.LoggedMinutes = _repositoryWrapper.ActivityRepository.GetLoggedTimeOnProject(_.Id); return _; });
			}

			return Ok(projects);
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetProject))]
		public IActionResult GetProject(Guid id, [FromQuery] bool includeTime = false)
		{
			var project = _repositoryWrapper.ProjectRepository.GetById(id);

			if(project == null) 
			{
				return NotFound("Project was not found");
			}

			if(includeTime) 
			{
				project.LoggedMinutes = _repositoryWrapper.ActivityRepository.GetLoggedTimeOnProject(id);
			}
						
			return Ok(project);
		}

		[HttpGet]
		[Route("{id:Guid}/activities", Name = nameof(GetProjectActivities))]
		public IActionResult GetProjectActivities(Guid id)
		{
			return Ok(_repositoryWrapper.ActivityRepository.GetEntitiesForParentId(id));
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

			var createdProject = _repositoryWrapper.ProjectRepository.Add(project);

			if(!_repositoryWrapper.PersistDbChanges())
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
			var project = _repositoryWrapper.ProjectRepository.GetById(id);

			if(project == null) 
			{
				return BadRequest("Project has not been found");
			}

			_repositoryWrapper.ProjectRepository.Delete(project);

			if(!_repositoryWrapper.PersistDbChanges())
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

			var project = _repositoryWrapper.ProjectRepository.GetById(id);

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

				_repositoryWrapper.ProjectRepository.Update(project);

				if(!_repositoryWrapper.PersistDbChanges())
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
