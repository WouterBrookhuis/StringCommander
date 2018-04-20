using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    abstract class Command
    {
        public string Name { get; private set; }
        public string Help { get; protected set; }

        public Command(string name)
        {
            Name = name;
            Help = "Unknown";
        }

        public virtual void Invoke(string[] args)
        {
        }
    }
}
