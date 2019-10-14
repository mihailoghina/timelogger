using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.Extensions.Logging;

namespace Timelogger.Api.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApiContext _apiContext;
        private IUsersRepository _userRepository;
        private IProjectsRepository _projectRepository;
        private IActivityRepository _activityRepository;

        public RepositoryWrapper(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
 
        public IUsersRepository UserRepository => _userRepository ?? new UsersRepository(_apiContext);

        public IProjectsRepository ProjectRepository => _projectRepository ?? new ProjectsRepository(_apiContext);

        public IActivityRepository ActivityRepository => _activityRepository ?? new ActivityRepository(_apiContext);
    
    }
}