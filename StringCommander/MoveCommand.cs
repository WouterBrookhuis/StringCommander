using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class MoveCommand : Command
    {
        public MoveCommand() : base("move")
        {
            Help = "Moves you around the world.\nValid directions include up down north east south west, although this may vary.";
        }

        public override void Invoke(string[] args)
        {
            if(args.Length != 1)
            {
                Program.ShowMessage("We need a direction to move in");
                return;
            }

            Direction dir;
            if(Enum.TryParse(args[0].ToUpperInvariant(), out dir))
            {
                if(!Program.TryMove(dir))
                {
                    Program.ShowMessage("Only a solid wall lies in that direction");
                }
            }
            else
            {
                Program.ShowMessage(args[0] + " is not a known direction");
            }
        }
    }
}
