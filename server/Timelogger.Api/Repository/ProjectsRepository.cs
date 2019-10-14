using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApiContext _context;

        public ProjectsRepository(ApiContext context) 
        {
            _context = context;
        } 

        public Project GetById(Guid id, bool includeChildren = false)
        {
            Project project = _context.Projects.SingleOrDefault(_ => _.Id == id);

            return project;
        } 

        public IEnumerable<Project> GetEntitiesForParentId(Guid id, bool includeChildren = false)
        {
            List<Project> projects = _context.Projects.Where(_ => _.CreatedBy == id).OrderBy(_ => _.DeadLineDate).ToList();

            return projects;
        }

        public IEnumerable<Project> GetAll(bool includeChildren = false) 
        {           
            List<Project> projects = _context.Projects.OrderBy(_ => _.DeadLineDate).ToList();
            
            return projects;            
        } 
       
        public Project Add(Project project) 
        {
            _context.Projects.Add(project);

            return project;        
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public void Delete(Project project) 
        {
            _context.Projects.Remove(project);
        }
     
    }
}