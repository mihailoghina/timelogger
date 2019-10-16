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

        public Project GetById(Guid id)
        {
            return _context.Projects.SingleOrDefault(_ => _.Id == id);
        } 

        public IEnumerable<Project> GetEntitiesForParentId(Guid id)
        {
            return _context.Projects.Where(_ => _.CreatedBy == id).OrderBy(_ => _.IsComplete).ThenBy(_ => _.DeadLineDate);
        }

        public IEnumerable<Project> GetAll() 
        {           
            return _context.Projects.OrderBy(_ => _.IsComplete).ThenBy(_ => _.DeadLineDate);        
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