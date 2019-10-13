using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.Extensions.Logging;

namespace Timelogger.Api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger _logger;
        private readonly IProjectsRepository _projectsRepository;

        public UsersRepository(ApiContext context, ILogger<UsersRepository> logger, IProjectsRepository projectsRepository) 
        {
            _context = context;
            _logger = logger;
            _projectsRepository = projectsRepository;
        } 

        public User GetById(Guid id, bool includeChildren = false)
        {
            User user = _context.Users.SingleOrDefault(_ => _.Id == id);

            if(includeChildren && user != null)
            {
                user.UserProjects = _projectsRepository.GetEntitiesForParentId(user.Id, true).ToList();
            }
            
            return user;
        } 

        public IEnumerable<User> GetAll(bool includeChildren = false) 
        {
            List<User> usersList = _context.Users.ToList();
            
            if(includeChildren && usersList.Any()) 
            {
                usersList = usersList.Select( x => { x.UserProjects = _projectsRepository.GetEntitiesForParentId(x.Id, true).ToList(); return x; }).ToList();
            }

            return usersList;
        } 

        public User Add(User user) 
        {
            _context.Users.Add(user);
            if (PersistDbChanges())
            {
                 return user;
            }
            return (User)null;          
        }

        public bool PersistDbChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return false;
            }        
        }
        
    }
}