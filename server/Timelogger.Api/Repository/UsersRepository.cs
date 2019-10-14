using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiContext _context;

        public UsersRepository(ApiContext context) 
        {
            _context = context;
        } 

        public User GetById(Guid id, bool includeChildren = false)
        {
            User user = _context.Users.SingleOrDefault(_ => _.Id == id);

            return user;
        } 

        public IEnumerable<User> GetAll(bool includeChildren = false) 
        {
            List<User> usersList = _context.Users.ToList();

            return usersList;
        } 

        public User Add(User user) 
        {
            _context.Users.Add(user);

            return user;         
        }
        
    }
}