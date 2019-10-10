using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace Timelogger.Api.Repository
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApiContext _context;

        public ProjectsRepository(ApiContext context) => _context = context;

        public IEnumerable<Project> GetAll() => _context.Projects;

        public Project GetById(Guid id) => _context.Projects.Where(_ => _.Id == id).FirstOrDefault();
    }
}