using Xunit;
using Moq;
using Timelogger.Api.Repository;
using Timelogger.Entities;
using Timelogger.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace timelogger.tests
{
    public class ProjectsControllerTests
    {
        [Fact]
        public void ProjectController_UpdateClosedProject() 
        {
            Project project = new Project { IsComplete = true };
            ProjectUpdateDTO projectUpdateDTO = new ProjectUpdateDTO { };

            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(x => x.ProjectRepository.GetById(It.IsAny<Guid>())).Returns(project);
            
            ProjectsController projectsController = new ProjectsController(mock.Object);

            ObjectResult result = projectsController.UpdateProject(new Guid(), projectUpdateDTO) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Completed project cannot be modified", result.Value);
        }
        
    }

}
