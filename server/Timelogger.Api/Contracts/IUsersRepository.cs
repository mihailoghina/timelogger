using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IUsersRepository
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();    
        User Add(User user);
    }
}