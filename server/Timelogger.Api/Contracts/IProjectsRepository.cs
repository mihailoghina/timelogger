using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAll();
        Project GetById(Guid id);
        Project Add(Project project);
        bool Delete(Project project);
        bool Update(Project project);
        bool PersistDbChanges();
    }
}