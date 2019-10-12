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

        public ActivityRepository(ApiContext context, ILogger<ActivityRepository> logger) 
        {
            _context = context;
            _logger = logger;
        } 

        public IEnumerable<Activity> GetAll() 
        {
            return _context.Activities;
        } 
        public Activity GetById(Guid id)
        {
            return _context.Activities.SingleOrDefault(_ => _.Id == id);
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

        public bool Delete(Activity activity) 
        {
            _context.Activities.Remove(activity);
            return PersistDbChanges();
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

        public bool Update(Activity activity)
        {
            _context.Activities.Update(activity);
            return PersistDbChanges();
        }
    }
}