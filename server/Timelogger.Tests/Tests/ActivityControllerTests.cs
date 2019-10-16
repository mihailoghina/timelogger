using Xunit;
using Moq;
using Timelogger.Api.Repository;
using Timelogger.Entities;
using Timelogger.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace timelogger.tests
{
    public class ActivityControllerTests
    {
        [Fact]
        public void ActivityController_CreateActivityForClosedProject() 
        {
            CreateActivityDTO createActivityDTO = new CreateActivityDTO {};

            Project project = new Project 
            {
               IsComplete = true
            };

            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(x => x.ProjectRepository.GetById(It.IsAny<Guid>())).Returns(project);
            ActivitiesController activityController = new ActivitiesController(mock.Object);

            ObjectResult result = activityController.CreateActivity(createActivityDTO) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cannot create activity for a closed project", result.Value);
        }

        [Fact]
        public void ActivityController_UpdateActivityForClosedProject() 
        {
            ActivityUpdateDTO activityUpdateDTO = new ActivityUpdateDTO{};

            Project project = new Project { IsComplete = true};
            Activity activity = new Activity {};

            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(x => x.ProjectRepository.GetById(It.IsAny<Guid>())).Returns(project);
            mock.Setup(x => x.ActivityRepository.GetById(It.IsAny<Guid>())).Returns(activity);
            ActivitiesController activityController = new ActivitiesController(mock.Object);

            ObjectResult result = activityController.UpdateActivity(new Guid(), activityUpdateDTO) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cannot change activity of a closed project", result.Value);
        }

        [Fact]
        public void ActivityController_DeleteActivityForClosedProject() 
        {

            Project project = new Project { IsComplete = true};
            Activity activity = new Activity {};

            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(x => x.ProjectRepository.GetById(It.IsAny<Guid>())).Returns(project);
            mock.Setup(x => x.ActivityRepository.GetById(It.IsAny<Guid>())).Returns(activity);
            ActivitiesController activityController = new ActivitiesController(mock.Object);

            ObjectResult result = activityController.DeleteACtivity(new Guid()) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cannot delete activity of a closed project. Whole project can be deleted", result.Value);
        }
        
        [Fact]
        public void ActivityController_CreateActivity_VerifyLoggedTimeMoreThan30Minutes() 
        {

            CreateActivityDTO createActivityDTO = new CreateActivityDTO 
            {
                Name = "activity name",
                Description = "description",
                LoggedMinutes = 29
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(createActivityDTO, new ValidationContext(createActivityDTO), validationResults, true);

            Assert.Equal(1, validationResults.Count);
            Assert.Equal("Minimum logged time must exceed 30 minutes", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ActivityController_CreateActivity_VerifyActivityNameMoreThan5characters() 
        {

            CreateActivityDTO createActivityDTO = new CreateActivityDTO 
            {
                Name = "name",
                Description = "description",
                LoggedMinutes = 50
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(createActivityDTO, new ValidationContext(createActivityDTO), validationResults, true);

            Assert.Equal(1, validationResults.Count);
            Assert.Equal("Activity name must have at least 5 characters", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ActivityController_UpdateActivity_VerifyLoggedTimeMoreThan30Minutes() 
        {

            ActivityUpdateDTO activityUpdateDTO = new ActivityUpdateDTO 
            {
                Name = "activity name",
                Description = "description",
                LoggedMinutes = 29
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(activityUpdateDTO, new ValidationContext(activityUpdateDTO), validationResults, true);

            Assert.Equal(1, validationResults.Count);
            Assert.Equal("Minimum logged time must exceed 30 minutes", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ActivityController_UpdateActivity_VerifyActivityNameMoreThan5characters() 
        {

            ActivityUpdateDTO activityUpdateDTO = new ActivityUpdateDTO 
            {
                Name = "name",
                Description = "description",
                LoggedMinutes = 50
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(activityUpdateDTO, new ValidationContext(activityUpdateDTO), validationResults, true);

            Assert.Equal(1, validationResults.Count);
            Assert.Equal("Activity name must have at least 5 characters", validationResults[0].ErrorMessage);
        }
    }

}
