using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAPI.Controllers;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;
using CommandAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CommandAPI.Tests
{
    public class CommandControllerTest : IDisposable
    {
        Mock<ICommandAPIRepo> mockRepo;
        IMapper mapper;
        MapperConfiguration configuration;

        CommandProfile realProfile;

        public CommandControllerTest()
        {
            mockRepo = new Mock<ICommandAPIRepo>();
            realProfile = new CommandProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }
        public void Dispose()
        {
            mapper = null;
            realProfile = null;
            configuration = null;
            mockRepo = null;

        }

        [Fact]
        public void GetCommandItems_Return200Ok_WhenDbIsEmpty()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

            var controller = new CommandController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


        [Fact]
        public void GetCommandItems_ReturnOneItem_WhenDbHasOneItem()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));

            var controller = new CommandController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var command = okResult.Value as List<CommandReadDto>;

            Assert.Single(command);
        }

        [Fact]
        public void GetCommandItemsById_Return200Ok_WhenValidIdProvided()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Commands
            {
                Id = 1,
                HowTo = "Mock",
                CommandLine = "Mock",
                Platform = "Mock"
            });

            var controller = new CommandController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetCommandById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


        [Fact]
        public void GetCommandById_ReturnNotFound_WhenInValidProvided()
        {
            mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(() => null);
            var controller = new CommandController(mockRepo.Object, mapper);

            var result = controller.GetCommandById(2);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetCommandById_Return200Ok_WhenVailIdProvided_ReturnReadDto()
        {
            mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Commands
            {
                Id = 1,
                HowTo = "Mock",
                CommandLine = "Mock",
                Platform = "Mock"
            });

            var controller = new CommandController(mockRepo.Object, mapper);

            var result = controller.GetCommandById(1);

            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }



        private List<Commands> GetCommands(int id)
        {
            var commands= new List<Commands>();
            if(id > 0)
            {
                commands.Add(
                    new Commands
                    {
                        Id = 0,
                        HowTo = "How to run a dotnet project",
                        CommandLine = "dotnet run",
                        Platform = "Dotnet CLI"
                    }
                );
            }  
            return commands;  
        }
    }
}            