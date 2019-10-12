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
		private readonly IUsersRepository _repo;
        public UsersController(IUsersRepository repo) 
		{
			_repo = repo;
		} 

        [HttpGet("{includeUserProjects:bool=false}", Name = nameof(GetAllUsers))]
        public IActionResult GetAllUsers(bool includeUserProjects) 
		{
			return Ok(_repo.GetAll(includeUserProjects));
		} 

        [HttpGet]
		[Route("{id:Guid}/{includeUserProjects:bool=false}", Name = nameof(GetUser))]
		public IActionResult GetUser(Guid id, bool includeUserProjects)
		{
			var user = _repo.GetById(id, includeUserProjects);

			if(user == null) 
			{
				return NotFound("User was not found");
			}
						
			return Ok(user);
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

			var createdUser = _repo.Add(user);

			if(createdUser == null)
			{
				return new ContentResult
				{
					StatusCode = 500,
					Content = $"Error occured while attempting to add user"
				};					
			}

			return CreatedAtAction(nameof(createdUser), new { id = createdUser.Id }, createdUser);			
		}
	}
}
