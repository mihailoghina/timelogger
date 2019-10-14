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

        public User GetById(Guid id)
        {
            return _context.Users.SingleOrDefault(_ => _.Id == id);
        } 

        public IEnumerable<User> GetAll() 
        {
            return _context.Users;
        } 

        public User Add(User user) 
        {
            _context.Users.Add(user);

            return user;         
        }
        
    }
}