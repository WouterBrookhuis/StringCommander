using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class Room
    {
        public string Description { get; set; }

        private Dictionary<Direction, Room> connections;

        public Room()
        {
            connections = new Dictionary<Direction, Room>();
        }

        public void ConnectTo(Room other, Direction to, Direction from)
        {
            connections[to] = other;
            other.connections[from] = this;
        }

        public Room GetConnected(Direction direction)
        {
            Room room;
            connections.TryGetValue(direction, out room);
            return room;
        }
    }
}
