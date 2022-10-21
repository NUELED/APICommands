using Commands.Models;
using Microsoft.EntityFrameworkCore;

namespace Commands.data
{
   public class CommandsContext : DbContext
   {
        public CommandsContext(DbContextOptions<CommandsContext> options) : base(options)
        {
        }  

        public DbSet<Command> Commands {get; set;}

   }

}