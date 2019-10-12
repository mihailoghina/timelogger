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

        public UsersRepository(ApiContext context, ILogger<UsersRepository> logger) 
        {
            _context = context;
            _logger = logger;
        } 

        public IEnumerable<User> GetAll(bool includeUserProjects = false) 
        {
            List<User> usersList = _context.Users.ToList();
            
            if(includeUserProjects && usersList.Any()) 
            {
                for(int i = 0; i < usersList.Count(); i++)
                {
                    usersList[i].UserProjects = _context.Projects.Where(_ => _.CreatedBy == usersList[i].Id).ToList();
                }
            }

            return _context.Users;
        } 

        public User GetById(Guid id, bool includeUserProjects = false)
        {
            User user = _context.Users.Where(_ => _.Id == id).FirstOrDefault();

            if(includeUserProjects && user != null)
            {
                user.UserProjects = _context.Projects.Where(_ => _.CreatedBy == id).ToList();
            }
            
            return user;
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