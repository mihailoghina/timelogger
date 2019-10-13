using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IActivityRepository
    {
        Activity GetById(Guid id, bool includeChildren = false);
        IEnumerable<Activity> GetEntitiesForParentId(Guid projectId, bool includeChildren = false);
        IEnumerable<Activity> GetAll(bool includeChildren = false);
        Activity Add(Activity activity);
        bool Update(Activity activity);
        bool Delete(Activity activity);    
        void RemoveEntitiesForParentId(Guid projectId);
        bool PersistDbChanges();
    }
}