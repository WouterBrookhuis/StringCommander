using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class SearchCommand : Command
    {
        public SearchCommand() : base("search")
        {
            Help = "Searches an item or room in an attempt to discover hidden items or secrets";
        }

        public override void Invoke(string[] args)
        {
            if(args.Length == 1)
            {
                SearchItem(args[0]);
                Program.ShowMessage("Finished searching");
            }
            else
            {
                Program.ShowMessage("What to search");
            }
        }

        private void SearchRoom()
        {
            var connections = Program.CurrentRoom.GetConnections();
            // TODO: Skill check instead of revealing everything
            foreach(var con in connections)
            {
                con.MakeVisible();
            }
        }

        private void SearchItem(string name)
        {
            if(name == "room")
            {
                SearchRoom();
                return;
            }
            Program.ShowMessage("The void consumes");
        }
    }
}
