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
                    Name = "Planning",
                    Description = "some bla bla",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 10, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("17192066-e198-467f-8dd2-07cac6bdb5a4"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    Name = "Design",
                    Description = "Focus on look and feel",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 13, 10, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("252ce65b-6d2a-4bf0-a14f-3e2729b06214"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    Name = "Coding",
                    Description = "writing code",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 11, 10, 54, 10),
                }
            };

            context.Activities.AddRange(activities);

            context.SaveChanges();
        }

        public static void SeedRecords(ApiContext context)
        {
            var records = new List<Record>()
            {
                new Record()
                {                  
                    Id = Guid.Parse("26507237-4096-4d02-846d-db4dd51299ce"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding1",
                    Description = "description1",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 10, 9, 8, 54, 10)            
                },
                new Record()
                {
                    Id = Guid.Parse("e1e7876f-46f6-4791-8e53-a3b3d597e92f"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding2",
                    Description = "description2",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 10, 6, 6, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("b601dc39-8021-44e4-8705-8f24ac4b757e"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding3",
                    Description = "description4",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 10, 9, 10, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("bb9c690d-7cc5-4df8-8d1d-9a589f4ad164"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding5",
                    Description = "description5",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 10, 9, 10, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("a54e3e39-5077-47ad-b3d9-40989cefbbe9"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding6",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 9, 10, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("8f589c07-a225-4643-b24d-f184b476dfe1"),
                    ActivityId = Guid.Parse("7fb2d28b-a268-4929-b24b-d82b607301d0"),
                    LoggedMinutes = 30,
                    Name = "Coding6",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 9, 10, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("20a800e1-5be6-47f5-b82c-9e07025cb1aa"),
                    ActivityId = Guid.Parse("17192066-e198-467f-8dd2-07cac6bdb5a4"),
                    LoggedMinutes = 171,
                    Name = "Design1",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 8, 12, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("a549abb9-0657-44fb-836f-7bdfcef08954"),
                    ActivityId = Guid.Parse("17192066-e198-467f-8dd2-07cac6bdb5a4"),
                    LoggedMinutes = 324,
                    Name = "Design2",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 8, 6, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("7c3a8f11-f5a3-4a17-8faa-e2742488024a"),
                    ActivityId = Guid.Parse("252ce65b-6d2a-4bf0-a14f-3e2729b06214"),
                    LoggedMinutes = 240,
                    Name = "Coding1",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 14, 12, 54, 10)       
                },
                new Record()
                {
                    Id = Guid.Parse("39b4e3b0-32f1-499f-8371-a739ed69cb1d"),
                    ActivityId = Guid.Parse("252ce65b-6d2a-4bf0-a14f-3e2729b06214"),
                    LoggedMinutes = 360,
                    Name = "Coding1",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate =  new DateTime(2019, 9, 13, 6, 54, 10)       
                },
            };
            context.Records.AddRange(records);

            context.SaveChanges();
        }
    }
}