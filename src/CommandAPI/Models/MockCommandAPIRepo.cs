using CommandAPI.Data;
using CommandAPI.Dtos;

namespace CommandAPI.Models
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void CreateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commands> GetAllCommands()
        {
            var commands = new List<Commands>
            {
                new Commands 
                { 
                    Id = 0, 
                    HowTo = "How to generate a migration", 
                    CommandLine = "dotnet ef migrations add <Name of Migration>", 
                    Platform = ".Net Core EF" 
                },
                new Commands 
                { 
                    Id = 1, 
                    HowTo = "Run Migrations",
                    CommandLine = "dotnet ef database update", 
                    Platform = ".Net Core EF" 
                },
                new Commands 
                {
                    Id = 2, 
                    HowTo = "List active Migrations", 
                    CommandLine = "dotnet ef migrations list", 
                    Platform = ".Net Core EF" 
                }
            };

            return commands;
        }

        public Commands GetCommandById(int id)
        {
            var command = new Commands 
            { 
                Id = 0, 
                HowTo = "How to generate a migration", 
                CommandLine = "dotnet ef migrations add <Name of Migration>", 
                Platform = ".Net Core EF" 
            };
            return command;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }
    }
}