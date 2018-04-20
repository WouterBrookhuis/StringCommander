using StringCommander.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class Program
    {
        private static bool quit;
        private static Room room;
        private static Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public static Room CurrentRoom { get => room; }

        static void Main(string[] args)
        {
            room = new Room("An open field", "A fairly large open field with grass and flowers");
            var room2 = new Room("A barn", "A red barn, as far as the degraded paint can still be considered red, with a large slightly ajar door. It does not appear to have been used any time recently");
            var room3 = new Room("Barn Cellar", "The cellar underneath a barn, it appears to be almost completely covered in cobwebs. But even the spiders seem to have left a long time ago and all that remains is a thick layer of dust");
            room.ConnectTo(room2, Direction.EAST, Direction.WEST);
            room2.ConnectTo(room3, Direction.DOWN, Direction.UP, false);
            AddCommand(new MoveCommand());
            AddCommand(new SearchCommand());
            AddCommand(new AliasCommand("go", new MoveCommand()));
            AddCommand(new QuitCommand());
            AddCommand(new AliasCommand("die", new QuitCommand()));
            AddCommand(new AliasCommand("exit", new QuitCommand()));

            UIManager.Instance.Initialize(80, 25, new RoomWindow(room));

            OnRoomChanged();

            quit = false;
            do
            {
                var input = Console.ReadLine().ToLowerInvariant().Split(null);
                UIManager.Instance.Begin();

                if (input.Length != 0)
                {
                    Command command;
                    if (commands.TryGetValue(input[0], out command))
                    {
                        string[] comArgs = new string[input.Length - 1];
                        Array.Copy(input, 1, comArgs, 0, comArgs.Length);
                        command.Invoke(comArgs);
                    }
                    else if (input[0].Length > 0)
                    {
                        ShowMessage("Unknown command " + input[0]);
                    }
                }

                UIManager.Instance.HandleInput(input);
            } while(!quit);
        }

        private static void AddCommand(Command command)
        {
            commands[command.Name] = command;
        }

        public static bool TryMove(Direction direction)
        {
            var newRoom = room.GetConnected(direction);
            if(newRoom != null)
            {
                room = newRoom.room;
                newRoom.MakeVisible();

                OnRoomChanged();
                return true;
            }
            return false;
        }

        public static void ShowMessage(string msg)
        {
            UIManager.Instance.ShowMessage(msg);
        }

        public static void OnRoomChanged()
        {
            UIManager.Instance.ShowWindow(new RoomWindow(room));
        }

        public static void Exit()
        {
            quit = true;
        }
    }
}
