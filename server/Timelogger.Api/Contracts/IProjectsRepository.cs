using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IProjectsRepository
    {
        Project GetById(Guid id, bool includeChildren = false);
        IEnumerable<Project> GetEntitiesForParentId(Guid id, bool includeChildren = false);
        IEnumerable<Project> GetAll(bool includeChildren = false);
        Project Add(Project project);
        void Update(Project project);
        void Delete(Project project);   
    }
}