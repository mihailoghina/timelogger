using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.Extensions.Logging;

namespace Timelogger.Api.Repository
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger _logger;
        private readonly IActivityRepository _activityRepository;

        public ProjectsRepository(ApiContext context, ILogger<ProjectsRepository> logger, IActivityRepository activityRepository) 
        {
            _context = context;
            _logger = logger;
            _activityRepository = activityRepository;
        } 

        public IEnumerable<Project> GetEntitiesForParentId(Guid id, bool includeChildren = false)
        {
            List<Project> projects = _context.Projects.Where(_ => _.CreatedBy == id).OrderBy(_ => _.DeadLineDate).ToList();

            if(includeChildren && projects.Any())
            {
               projects = projects.Select( x => { x.ProjectActivities = _activityRepository.GetEntitiesForParentId(x.Id, true); return x; }).ToList();
            }
            
            return projects;
        }

        public IEnumerable<Project> GetAll(bool includeChildren = false) 
        {           
            List<Project> projects = _context.Projects.OrderBy(_ => _.DeadLineDate).ToList();

            if(includeChildren && projects.Any())
            {
               projects = projects.Select( x => { x.ProjectActivities = _activityRepository.GetEntitiesForParentId(x.Id, true); return x; }).ToList();
            }
            
            return projects;
            
        } 
        public Project GetById(Guid id, bool includeChildren = false)
        {
            Project project = _context.Projects.SingleOrDefault(_ => _.Id == id);

            if(includeChildren && project != null) 
            {
                project.ProjectActivities = _activityRepository.GetEntitiesForParentId(id, true);
            }

            return project;
        } 

        public Project Add(Project project) 
        {
            _context.Projects.Add(project);
            if (PersistDbChanges())
            {
                 return project;
            }
            return (Project)null;          
        }

        public bool Delete(Project project) 
        {
            _context.Projects.Remove(project);
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

        public bool Update(Project project)
        {
            _context.Projects.Update(project);
            return PersistDbChanges();
        }
    }
}