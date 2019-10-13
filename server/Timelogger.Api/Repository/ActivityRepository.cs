using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.Extensions.Logging;

namespace Timelogger.Api.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger _logger;
        private readonly IRecordRepository _recordRepository;

        public ActivityRepository(ApiContext context, ILogger<ActivityRepository> logger, IRecordRepository recordRepository) 
        {
            _context = context;
            _logger = logger;
            _recordRepository = recordRepository;
        } 

        public Activity GetById(Guid id, bool includeChildren = false)
        {
            Activity activity = _context.Activities.SingleOrDefault(_ => _.Id == id);

            if(includeChildren && activity != null)
            {
                activity.ActivityRecords = _recordRepository.GetEntitiesForParentId(id).ToList();
            }

            return activity;
        } 

        public IEnumerable<Activity> GetEntitiesForParentId(Guid projectId, bool includeChildren = false)
        {
            List<Activity> activities = _context.Activities.Where(_ => _.ProjectId == projectId).ToList();

            if(includeChildren && activities.Any())
            {
                activities = activities.Select(x => { x.ActivityRecords = _recordRepository.GetEntitiesForParentId(x.Id).ToList(); return x; }).ToList();
            }

            return activities;
        }

        public IEnumerable<Activity> GetAll(bool includeChildren = false) 
        {
            List<Activity> activities = _context.Activities.ToList();

            if(includeChildren && activities.Any())
            {
                activities = activities.Select(x => { x.ActivityRecords = _recordRepository.GetEntitiesForParentId(x.Id).ToList(); return x; }).ToList();
            }

            return activities;
        } 
        
        public Activity Add(Activity activity) 
        {
            _context.Activities.Add(activity);
            if (PersistDbChanges())
            {
                 return activity;
            }
            return (Activity)null;          
        }

        public bool Update(Activity activity)
        {
            _context.Activities.Update(activity);
            return PersistDbChanges();
        }

        public bool Delete(Activity activity) 
        {
            _context.Activities.Remove(activity);

            _recordRepository.RemoveEntitiesForParentId(activity.Id);

            return PersistDbChanges();
        }

        public void RemoveEntitiesForParentId(Guid projectId)
        {
            var activities = GetEntitiesForParentId(projectId).ToList();

            activities.ForEach(x => _recordRepository.RemoveEntitiesForParentId(x.Id));
        }

        public bool PersistDbChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return false;
            }        
        }
      
    }
}