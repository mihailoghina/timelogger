using Timelogger.Entities;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Timelogger.Api
{
    public static class SeedDatabase
    {
        
        public static void SeedUsers(ApiContext context) 
        {
            var users = new List<User>()	
            {
                new User
                {
                    Id = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    Email = "mihailoghina@gmail.com",
                    Name = "Mihai Loghina",
                    PathToAvatar = null,
                    CreationDate = DateTime.Now,
                    UserProjects =  null
                },
                new User
                {
                    Id = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    Email = "abc123@gmail.com",
                    Name = "abc123",
                    PathToAvatar = null,
                    CreationDate = DateTime.Now,
                    UserProjects =  null
                },
                new User
                {
                    Id = Guid.Parse("f31fa5b1-6ce9-441c-8378-7ef2ebc45bcb"),
                    Email = "abc1234@gmail.com",
                    Name = "abc1234",
                    PathToAvatar = null,
                    CreationDate = DateTime.Now,
                    UserProjects =  null
                } 
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        public static void SeedProjects(ApiContext context)
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    Id = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    Name = "Build interview application",
                    CreationDate = DateTime.Now,
                    DeadLineDate = new DateTime(2019, 10, 20),
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5")
                },
                new Project()
                {
                    Id = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    Name = "Rebuild bike",
                    CreationDate = DateTime.Now,
                    DeadLineDate = new DateTime(2019, 10, 25),
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5")
                },
                new Project()
                {
                    Id = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    Name = "Design race car",
                    CreationDate = DateTime.Now,
                    DeadLineDate = new DateTime(2019, 10, 23),
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5")
                }
            };

            context.Projects.AddRange(projects);

            context.SaveChanges();
        }

        public static void SeedActivities(ApiContext context)
        {

            var activities = new List<Activity>()
            {
                new Activity()
                {
                    Id = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 45,
                    Name = "Planning",
                    Description = "some bla bla",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 10, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("17192066-e198-467f-8dd2-07cac6bdb5a4"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 180,
                    Name = "Design",
                    Description = "Focus on look and feel",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 13, 10, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("252ce65b-6d2a-4bf0-a14f-3e2729b06214"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 120,
                    Name = "Coding",
                    Description = "writing code",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 11, 10, 54, 10),
                }
            };

            context.Activities.AddRange(activities);

            context.SaveChanges();
        }
    }
}