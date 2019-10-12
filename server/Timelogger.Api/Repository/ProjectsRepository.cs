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

        public ProjectsRepository(ApiContext context, ILogger<ProjectsRepository> logger) 
        {
            _context = context;
            _logger = logger;
        } 

        public IEnumerable<Project> GetAll() 
        {
            return _context.Projects;
        } 
        public Project GetById(Guid id)
        {
            return _context.Projects.SingleOrDefault(_ => _.Id == id);
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