using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IActivityRepository
    {
        Activity GetById(Guid id);
        IEnumerable<Activity> GetEntitiesForParentId(Guid projectId);
        IEnumerable<Activity> GetAll();
        Activity Add(Activity activity);
        void Update(Activity activity);
        void Delete(Activity activity);    
        void RemoveEntitiesForParentId(Guid projectId);
    }
}