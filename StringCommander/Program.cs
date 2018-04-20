using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class Program
    {
        private static Room room;

        static void Main(string[] args)
        {
            var commands = new List<Command>();
            commands.Add(new MoveCommand());
            room = new Room();
            var room2 = new Room();
            room.ConnectTo(room2, Direction.EAST, Direction.WEST);

            bool quit = false;
            do
            {
                var input = Console.ReadLine().ToLowerInvariant().Split(null);
                if(input.Length != 0)
                {
                    
                }
            } while(!quit);
        }

        public static bool TryMove(Direction direction)
        {
            var newRoom = room.GetConnected(direction);
            if(newRoom != null)
            {
                room = newRoom;
                return true;
            }
            return false;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
