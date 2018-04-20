using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander.UI
{
    class RoomWindow : Window
    {
        Room room;

        public RoomWindow(Room room) : base(room.Name)
        {
            this.room = room;
        }

        public override void Display()
        {
            DisplayTitle();
            Console.SetCursorPosition(1, 2);
            Console.Write("Description:");
            Console.SetCursorPosition(2, 3);
            Console.Write(room.Description);
            Console.SetCursorPosition(1, Console.CursorTop + 1);
            Console.Write("Connections:");
            var connections = room.GetVisibleConnections();
            int row = Console.CursorTop + 1;
            foreach(var connection in connections)
            {
                Console.SetCursorPosition(2, row++);
                Console.WriteLine("{0}: {1}", connection.direction.ToString().ToLowerInvariant(), connection.room.Name);
            }
        }
    }
}
