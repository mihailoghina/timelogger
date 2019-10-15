using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Api.Repository;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly IRepositoryWrapper _repositoryWrapper;
        public UsersController(IRepositoryWrapper repositoryWrapper) 
		{
			_repositoryWrapper = repositoryWrapper;
		} 

        [HttpGet(Name = nameof(GetAllUsers))]
        public IActionResult GetAllUsers() 
		{
			return Ok(_repositoryWrapper.UserRepository.GetAll());
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetUser))]
		public IActionResult GetUser(Guid id)
		{
			var user = _repositoryWrapper.UserRepository.GetById(id);

			if(user == null) 
			{
				return NotFound("User was not found");
			}
						
			return Ok(user);
		}

		[HttpGet]
		[Route("{id:Guid}/projects", Name = nameof(GetUserProjects))]
		public IActionResult GetUserProjects(Guid id, [FromQuery] bool includeTime = false)
		{
			var projects = _repositoryWrapper.ProjectRepository.GetEntitiesForParentId(id);

			if(includeTime)
			{
				projects = projects.Select( _ => { _.LoggedMinutes = _repositoryWrapper.ActivityRepository.GetLoggedTimeOnProject(_.Id); return _; });
			}

			return Ok(projects);
		}

		[HttpPost(Name = nameof(CreateUser))]
		public IActionResult CreateUser([FromBody] CreateUserDTO createUserDTO)
		{
			if(createUserDTO == null) 
			{
				return BadRequest("invalid payload");
			}

			if(!ModelState.IsValid)
			{
				var message = string.Join("\n", ModelState.Values
									.SelectMany(v => v.Errors)
									.Select(e => e.ErrorMessage));

				return BadRequest(message);
			}

			var user = new User
			{
				Id = Guid.NewGuid(),
				Name = createUserDTO.Name,
                PathToAvatar = createUserDTO.PathToAvatar,
                Email = createUserDTO.Email,
				CreationDate = DateTime.Now
			};		

			var createdUser = _repositoryWrapper.UserRepository.Add(user);

			if(!_repositoryWrapper.PersistDbChanges())
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to add user"
				};					
			}

			return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);			
		}
	}
}
