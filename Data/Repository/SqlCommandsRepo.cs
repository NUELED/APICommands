using Commands.data;
using Commands.Models;

namespace commands.data. Repository
{
    public class SqlCommandsRepo : ICommandsRepo
    {
        private readonly CommandsContext _db;
        public SqlCommandsRepo(CommandsContext db)
        {
            _db = db;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
               throw new ArgumentNullException(nameof(cmd));
            }
            _db.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
               throw new ArgumentNullException(nameof(cmd));
            }

            _db.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return  _db.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _db.Commands.FirstOrDefault(p => p.id==id);
        }

        public bool SaveChanges()
        {
           return (_db.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }



}