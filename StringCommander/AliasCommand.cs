using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class AliasCommand : Command
    {
        private Command command;

        public AliasCommand(string name, Command command) : base(name)
        {
            this.command = command;
            this.Help = command.Help;
        }

        public override void Invoke(string[] args)
        {
            command.Invoke(args);
        }
    }
}
