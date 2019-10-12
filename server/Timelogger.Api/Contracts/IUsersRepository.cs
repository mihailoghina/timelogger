using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll(bool includeChildren = false);
        User GetById(Guid id, bool includeChildren = false);
        User Add(User user);
        bool PersistDbChanges();
    }
}