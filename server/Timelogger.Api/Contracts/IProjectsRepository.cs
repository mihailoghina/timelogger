using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IProjectsRepository
    {
        Project GetById(Guid id);
        IEnumerable<Project> GetEntitiesForParentId(Guid id);
        IEnumerable<Project> GetAll();
        Project Add(Project project);
        void Update(Project project);
        void Delete(Project project);   
    }
}