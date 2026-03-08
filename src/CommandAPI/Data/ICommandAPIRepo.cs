using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ICommandAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Commands> GetAllCommands();
        Commands GetCommandById(int id);
        void CreateCommand(Commands cmd);   
        void UpdateCommand(Commands cmd);
        void DeleteCommand(Commands cmd);

    }
}