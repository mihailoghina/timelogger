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
		private readonly IUsersRepository _usersRepo;
		private readonly IProjectsRepository _projectsRepo;
        public UsersController(IUsersRepository usersRepo, IProjectsRepository projectRepo) 
		{
			_usersRepo = usersRepo;
			_projectsRepo = projectRepo;
		} 

        [HttpGet(Name = nameof(GetAllUsers))]
        public IActionResult GetAllUsers([FromQuery] bool includeChildren) 
		{
			return Ok(_usersRepo.GetAll(includeChildren));
		} 

        [HttpGet]
		[Route("{id:Guid}", Name = nameof(GetUser))]
		public IActionResult GetUser(Guid id, [FromQuery] bool includeChildren)
		{
			var user = _usersRepo.GetById(id, includeChildren);

			if(user == null) 
			{
				return NotFound("User was not found");
			}
						
			return Ok(user);
		}

		[HttpGet]
		[Route("{id:Guid}/projects", Name = nameof(GetUserProjects))]
		public IActionResult GetUserProjects(Guid id, [FromQuery] bool includeChildren)
		{
			return Ok(_projectsRepo.GetEntitiesForParentId(id, includeChildren));
		}

		[HttpPost(Name = nameof(CreateUser))]
		public IActionResult CreateUser([FromBody] CreateUserDTO createUserDTO)
		{
			if(createUserDTO == null) 
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

			var user = new User
			{
				Id = Guid.NewGuid(),
				Name = createUserDTO.Name,
                PathToAvatar = createUserDTO.PathToAvatar,
                Email = createUserDTO.Email,
				CreationDate = DateTime.Now
			};		

			var createdUser = _usersRepo.Add(user);

			if(createdUser == null)
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
