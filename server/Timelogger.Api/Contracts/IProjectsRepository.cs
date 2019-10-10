using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAll();
        Project GetById(Guid id);
    }
}