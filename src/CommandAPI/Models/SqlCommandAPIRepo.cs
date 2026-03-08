using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Dtos;

namespace CommandAPI.Models
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        private readonly IMapper _mapper;
        public SqlCommandAPIRepo(CommandContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateCommand(Commands cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
             _context.SaveChanges();
        }

        public void DeleteCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commands> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        public Commands GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id)!;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }
    }
}