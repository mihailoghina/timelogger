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
                },
                new User
                {
                    Id = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    Email = "abc123@gmail.com",
                    Name = "abc123",
                    PathToAvatar = null,
                    CreationDate = DateTime.Now,
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
                },
                new Project()
                {
                    Id = Guid.Parse("4b98a773-6101-435f-a9c2-f10358974831"),
                    Name = "2nd user project",
                    CreationDate = DateTime.Now,
                    DeadLineDate = new DateTime(2019, 10, 23),
                    CreatedBy = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa")
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
                },
                new Activity()
                {
                    Id = Guid.Parse("f47b2635-5874-4e93-bdf2-aa0adde73556"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 121,
                    Name = "implement feature 1",
                    Description = "writing code",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 8, 10, 54, 10),
                }
                ,
                new Activity()
                {
                    Id = Guid.Parse("ea0bced6-50c2-49c0-af75-cc94c40bc3fa"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 87,
                    Name = "implement feature 2",
                    Description = "description 2",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 9, 17, 20, 10),
                }
                ,
                new Activity()
                {
                    Id = Guid.Parse("91cad86e-e7ca-4248-82c5-794bf30918f9"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 39,
                    Name = "implement feature 3",
                    Description = "description 3",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 8, 22, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("f928b0e0-77cd-45b7-877b-44e2aedd6abf"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 49,
                    Name = "implement feature 4",
                    Description = "writing code 4",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 7, 10, 54, 10),
                }, 
                new Activity()
                {
                    Id = Guid.Parse("ac40e3e3-d136-4f0b-955b-e2b5cf8d8836"),
                    ProjectId = Guid.Parse("b8b939ba-b8b0-43e6-a80f-43cb47d3ab54"),
                    LoggedMinutes = 278,
                    Name = "implement feature 5",
                    Description = "writing code 5",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 6, 10, 54, 10),
                },  // REBUILD BIKE ACTIVITIES
                new Activity()
                {
                    Id = Guid.Parse("281f2222-023f-44e3-a40c-cc2da919dcfc"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 300,
                    Name = "change oil fork",
                    Description = "full service",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 3, 10, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("7f02a77a-5289-4fe3-857d-0b2e05123bba"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 100,
                    Name = "change shock oil",
                    Description = "full service",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 10, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("746d10af-97b9-4f4e-b255-75426310f71c"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 50,
                    Name = "service1",
                    Description = "service1 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 18, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("c1da1364-bae6-47f0-91c2-d9838be76bd1"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 80,
                    Name = "service2",
                    Description = "service2 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 18, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("aa0708da-a4f5-4690-b2bf-21f472a50af3"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 110,
                    Name = "service4",
                    Description = "service4 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 18, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("27291456-330f-4c38-a0ac-14a2d5046efc"),
                    ProjectId = Guid.Parse("849d1fe0-5750-485b-9485-67da7d3f4812"),
                    LoggedMinutes = 235,
                    Name = "service5",
                    Description = "service5 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 18, 54, 10),
                }, // DESIGN RACE CAR ACTIVITIES
                new Activity()
                {
                    Id = Guid.Parse("762027d6-036a-4c57-925e-492ee987fa4c"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 31,
                    Name = "design1",
                    Description = "design1 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 12, 32, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("dc40a5a6-a601-42b7-81d7-12b6b97a37fe"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 95,
                    Name = "design2",
                    Description = "design2 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 16, 44, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("2a350c8d-3d06-4385-9b54-6a49a511db74"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 235,
                    Name = "design3",
                    Description = "design3 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 4, 22, 47, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("d98dd076-c97e-4377-8fd3-9ae0a91f3f0a"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 235,
                    Name = "design4",
                    Description = "design4 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 5, 4, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("434e282c-0fc5-4721-a48a-c861c09c0806"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 235,
                    Name = "design4",
                    Description = "design4 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 5, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("3817276e-7edf-4d47-940d-c850913a85ff"),
                    ProjectId = Guid.Parse("0f5b0cba-7c3a-48bf-8d08-6756e498675d"),
                    LoggedMinutes = 235,
                    Name = "design5",
                    Description = "design5 desc",
                    CreatedBy = Guid.Parse("aaad9946-4201-41c7-825e-1d7c706c83f5"),
                    CreationDate = new DateTime(2019, 10, 6, 20, 54, 10),
                }, //2ND USER PROJECT ACTIVITIES
                new Activity()
                {
                    Id = Guid.Parse("6b254d9e-45b0-4d24-9081-88773084900a"),
                    ProjectId = Guid.Parse("4b98a773-6101-435f-a9c2-f10358974831"),
                    LoggedMinutes = 100,
                    Name = "activity1",
                    Description = "activity1 desc",
                    CreatedBy = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    CreationDate = new DateTime(2019, 10, 5, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("fff56d8f-78d0-4ea4-8e4c-ad4eaa59f122"),
                    ProjectId = Guid.Parse("4b98a773-6101-435f-a9c2-f10358974831"),
                    LoggedMinutes = 200,
                    Name = "activity2",
                    Description = "activity2 desc",
                    CreatedBy = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    CreationDate = new DateTime(2019, 10, 5, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("791845c5-1a4f-4cbf-beda-203663e92d10"),
                    ProjectId = Guid.Parse("4b98a773-6101-435f-a9c2-f10358974831"),
                    LoggedMinutes = 300,
                    Name = "activity3",
                    Description = "activity3 desc",
                    CreatedBy = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    CreationDate = new DateTime(2019, 10, 5, 7, 54, 10),
                },
                new Activity()
                {
                    Id = Guid.Parse("82b66d1b-3bcf-4a0a-8f64-e17753517dd4"),
                    ProjectId = Guid.Parse("4b98a773-6101-435f-a9c2-f10358974831"),
                    LoggedMinutes = 400,
                    Name = "activity4",
                    Description = "activity4 desc",
                    CreatedBy = Guid.Parse("b499c699-db0d-4336-a98a-5b63a2d417aa"),
                    CreationDate = new DateTime(2019, 10, 5, 7, 54, 10),
                },
            };

            context.Activities.AddRange(activities);

            context.SaveChanges();
        }
    }
}