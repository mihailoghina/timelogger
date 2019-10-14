using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApiContext _context;

        public ActivityRepository(ApiContext context) 
        {
            _context = context;
        } 

        public Activity GetById(Guid id)
        {
            Activity activity = _context.Activities.SingleOrDefault(_ => _.Id == id);

            return activity;
        } 

        public IEnumerable<Activity> GetEntitiesForParentId(Guid projectId)
        {
            List<Activity> activities = _context.Activities.Where(_ => _.ProjectId == projectId).ToList();

            return activities;
        }

        public IEnumerable<Activity> GetAll() 
        {
            List<Activity> activities = _context.Activities.ToList();

            return activities;
        } 
        
        public Activity Add(Activity activity) 
        {
            _context.Activities.Add(activity);

            return activity;        
        }

        public void Update(Activity activity)
        {
            _context.Activities.Update(activity);
        }

        public void Delete(Activity activity) 
        {
            _context.Activities.Remove(activity);
        }

        public void RemoveEntitiesForParentId(Guid projectId)
        {
            var activities = GetEntitiesForParentId(projectId).ToList();
        }
      
    }
}