using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAll(bool includeChildren = false);
        IEnumerable<Activity> GetEntitiesForParentId(Guid projectId, bool includeChildren = false);
        Activity GetById(Guid id, bool includeChildren = false);
        Activity Add(Activity activity);
        bool Delete(Activity activity);
        bool Update(Activity activity);
        bool PersistDbChanges();
    }
}