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
        private ILogger _logger;

        public RepositoryWrapper(ApiContext apiContext, ILogger logger)
        {
            _apiContext = apiContext;
            _logger = logger;
        }
 
        public IUsersRepository UserRepository => _userRepository ?? new UsersRepository(_apiContext);

        public IProjectsRepository ProjectRepository => _projectRepository ?? new ProjectsRepository(_apiContext);

        public IActivityRepository ActivityRepository => _activityRepository ?? new ActivityRepository(_apiContext);

        public bool PersistDbChanges()
        {
            try
            {
                return _apiContext.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return false;
            }        
        }
    
    }
}