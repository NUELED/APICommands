using Commands.Models;

namespace Commands.data.Repository
{
    public class CommandsRepo : ICommandsRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                  new Command { id = 0, HowTo="Boil an egg",  line="Boil Water", Platform="Kettle & Pan"},
                  new Command { id = 1, HowTo="Cut Bread",    line="Get a Knife", Platform="Knife & Chopping board"},
                  new Command { id = 2, HowTo="Make a cup of tea", line="Place tea Bag in cup", Platform="Kettle & cup"}

            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { id = 0, HowTo="Boil an egg", line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            //nothing
        }
    }
}