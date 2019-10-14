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
            return _context.Activities.Where(_ => _.ProjectId == projectId).OrderByDescending(_ => _.CreationDate);
        }

        public IEnumerable<Activity> GetAll() 
        {
            return _context.Activities;
        } 

        public int GetLoggedTimeOnProject(Guid projectId)
        {
            var activities = GetEntitiesForParentId(projectId);

            return activities.Sum(_ => _.LoggedMinutes);
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
            _context.Activities.RemoveRange(GetEntitiesForParentId(projectId));
        }
      
    }
}