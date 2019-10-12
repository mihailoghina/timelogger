using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAll(bool includeChildren = false);
        IEnumerable<Project> GetEntitiesForParentId(Guid id, bool includeChildren = false);
        Project GetById(Guid id, bool includeChildren = false);
        Project Add(Project project);
        bool Delete(Project project);
        bool Update(Project project);
        bool PersistDbChanges();
    }
}