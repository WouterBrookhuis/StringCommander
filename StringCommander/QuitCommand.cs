using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class QuitCommand : Command
    {
        public QuitCommand() : base("quit")
        {
        }

        public override void Invoke(string[] args)
        {
            Program.Exit();
        }
    }
}
