using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAll();
        Activity GetById(Guid id);
        Activity Add(Activity activity);
        bool Delete(Activity project);
        bool Update(Activity project);
        bool PersistDbChanges();
    }
}