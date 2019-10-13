using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Api.Repository;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class RecordsController : Controller
	{
		private readonly IActivityRepository _activityRepository;
		private readonly IRecordRepository _recordRepository;
        private readonly IProjectsRepository _projectRepository;
        public RecordsController(IActivityRepository activityRepository, IRecordRepository recordRepository, IProjectsRepository projectRepository) 
		{
			_activityRepository = activityRepository;
			_recordRepository = recordRepository;
            _projectRepository = projectRepository;
		} 

        [HttpGet(Name = nameof(GetAllRecords))]
        public IActionResult GetAllRecords() 
		{
			return Ok(_recordRepository.GetAll());
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetRecord))]
		public IActionResult GetRecord(Guid id)
		{
			var record = _recordRepository.GetById(id);

			if(record == null) 
			{
				return NotFound("Record was not found");
			}
						
			return Ok(record);
		}

		[HttpPost(Name = nameof(CreateRecord))]
		public IActionResult CreateRecord([FromBody] CreateRecordDTO createRecordDTO)
		{
			if(createRecordDTO == null) 
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

            //get corresponding activity
            var activity = _activityRepository.GetById(createRecordDTO.ActivityId);
            //get corresponding project
			var project = _projectRepository.GetById(activity.ProjectId);

			//prevent adding records to activity of a project which has been completed.
			//completed projects can be only deleted together with its activities and records
			if(project.IsComplete == true)
			{
				return BadRequest("Cannot log time to a closed project");
			}

			if(activity.CreatedBy != createRecordDTO.CreatedBy) 
			{
				return BadRequest("Only the owner of the activity is allowed to add records");
			}

			var record = new Record
			{
				Id = Guid.NewGuid(),
                ActivityId = createRecordDTO.ActivityId,
				LoggedMinutes = createRecordDTO.LoggedMinutes,
                Name = createRecordDTO.Name,
				Description = createRecordDTO.Description,
				CreatedBy = createRecordDTO.CreatedBy,
				CreationDate = DateTime.Now
			};		

			var createdRecord = _recordRepository.Add(record);

			if(createdRecord == null)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to add record"
				};					
			}

			return CreatedAtAction(nameof(CreateRecord), new { id = createdRecord.Id }, createdRecord);			
		}

		[HttpDelete]
		[Route("{id:Guid}", Name = nameof(DeleteRecord))]
		public IActionResult DeleteRecord(Guid id)
		{
			var record = _recordRepository.GetById(id);

			if(record == null) 
			{
				return BadRequest("Record has not been found");
			}

			if(!_recordRepository.Delete(record))
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to delete record. Record {id} was not deleted"
				};
			}
			
			return Ok();
		}

		[HttpPut]
        [Route("{id:Guid}", Name = nameof(UpdateRecord))]
        public IActionResult UpdateRecord(Guid id, [FromBody]RecordUpdateDTO recordUpdateDTO)
        {
            if (recordUpdateDTO == null)
            {
                return BadRequest();
            }

			var record = _recordRepository.GetById(id);

            if (record == null)
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

            var activity = _activityRepository.GetById(record.ActivityId);

			var project = _projectRepository.GetById(activity.ProjectId);

			//prevent modifying  records of a project which has been completed.
			//completed projects can be only deleted together with its activities and records
			if(project.IsComplete == true)
			{
				return BadRequest("Cannot change record of a closed project");
			}

            if(activity.CreatedBy != record.CreatedBy)
            {
                return BadRequest("Only the owner of activity can log time");
            }

			record.Name = recordUpdateDTO.Name;
			record.Description = recordUpdateDTO.Description;
            record.LoggedMinutes = record.LoggedMinutes;

			if(!_recordRepository.Update(record))
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to update activity. Activity {activity.Id} was not deleted"
				};	
			}

			return Ok(record);
			           
        }
	}
}
