using CommandAPI.Models;
namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Commands testCommand;
        public CommandTests()
        {
            // Setup code, if needed
             testCommand = new Commands
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }
        
        [Fact]
        public void CanChangeHowTo()
        {
            // Arrange
        

            // Act
            testCommand.HowTo = "How to generate a migration with dotnet CLI";

            // Assert
            Assert.Equal("How to generate a migration with dotnet CLI", testCommand.HowTo);
        }


            [Fact]
        public void CanChangeCommandLine()
        {
            // Arrange

            // Act
            testCommand.CommandLine = "dotnet ef migrations add <Name of Migration> -p <Path to Project>";

            // Assert
            Assert.Equal("dotnet ef migrations add <Name of Migration> -p <Path to Project>", testCommand.CommandLine);
        }

        [Fact]
        public void CanChangePlatform()
        {
            // Arrange

            // Act
            testCommand.Platform = ".Net Core EF with dotnet CLI";

            // Assert
            Assert.Equal(".Net Core EF with dotnet CLI", testCommand.Platform);
        }
        
    }
}