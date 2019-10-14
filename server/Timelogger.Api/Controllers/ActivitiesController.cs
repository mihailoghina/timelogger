using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Api.Repository;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ActivitiesController : Controller
	{
		private readonly IRepositoryWrapper _repositoryWrapper;
        public ActivitiesController(IRepositoryWrapper repositoryWrapper) 
		{
			_repositoryWrapper = repositoryWrapper;
		} 

        [HttpGet(Name = nameof(GetAllAcvtivities))]
        public IActionResult GetAllAcvtivities([FromQuery] bool includeChildren) 
		{
			return Ok(_repositoryWrapper.ActivityRepository.GetAll());
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetACtivity))]
		public IActionResult GetACtivity(Guid id, [FromQuery] bool includeChildren)
		{
			var activity = _repositoryWrapper.ActivityRepository.GetById(id);

			if(activity == null) 
			{
				return NotFound("Activity was not found");
			}
						
			return Ok(activity);
		}

		[HttpPost(Name = nameof(CreateActivity))]
		public IActionResult CreateActivity([FromBody] CreateActivityDTO createActivityDTO)
		{
			if(createActivityDTO == null) 
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

			var project = _repositoryWrapper.ProjectRepository.GetById(createActivityDTO.ProjectId);

			//prevent adding activities to project which has been completed.
			//completed projects can be only deleted together with its activities and records
			if(project.IsComplete == true)
			{
				return BadRequest("Cannot change activity of a closed project");
			}

			if(project.CreatedBy != createActivityDTO.CreatedBy) 
			{
				return BadRequest("Only the owner of the project is allowed to add activities");
			}

			var activity = new Activity
			{
				Id = Guid.NewGuid(),
                ProjectId = createActivityDTO.ProjectId,
				Name = createActivityDTO.Name,
				Description = createActivityDTO.Description,
				CreatedBy = createActivityDTO.CreatedBy,
				CreationDate = DateTime.Now
			};		

			var createdActivity = _repositoryWrapper.ActivityRepository.Add(activity);

			if(createdActivity == null)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to add activity"
				};					
			}

			return CreatedAtAction(nameof(CreateActivity), new { id = createdActivity.Id }, createdActivity);			
		}

		[HttpDelete]
		[Route("{id:Guid}", Name = nameof(DeleteACtivity))]
		public IActionResult DeleteACtivity(Guid id)
		{
			var activity = _repositoryWrapper.ActivityRepository.GetById(id);

			if(activity == null) 
			{
				return BadRequest("Activity has not been found");
			}

			if(!_repositoryWrapper.ActivityRepository.Delete(activity))
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to delete activity. Activity {id} was not deleted"
				};
			}
			
			return Ok();
		}

		[HttpPut]
        [Route("{id:Guid}", Name = nameof(UpdateActivity))]
        public IActionResult UpdateActivity(Guid id, [FromBody]ActivityUpdateDTO activityUpdateDTO)
        {
            if (activityUpdateDTO == null)
            {
                return BadRequest();
            }

			var activity = _repositoryWrapper.ActivityRepository.GetById(id);

            if (activity == null)
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

			var project = _repositoryWrapper.ProjectRepository.GetById(activity.ProjectId);

			//prevent modifying activities and later time records of a project which has been completed.
			//completed projects can be only deleted together with its activities and records
			if(project.IsComplete == true)
			{
				return BadRequest("Cannot change activity of a closed project");
			}

			activity.Name = activityUpdateDTO.Name;
			activity.Description = activityUpdateDTO.Description;

			if(!_repositoryWrapper.ActivityRepository.Update(activity))
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to update activity. Activity {activity.Id} was not deleted"
				};	
			}

			return Ok(activity);
			           
        }
	}
}
