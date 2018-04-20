using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class RoomConnection
    {
        public Room room;
        public Direction direction;
        public bool visible;
        public RoomConnection inverse;

        public RoomConnection(Room room, Direction direction, bool visible)
        {
            this.room = room;
            this.direction = direction;
            this.visible = visible;
        }

        public void MakeVisible()
        {
            this.visible = true;
            if(inverse != null)
            {
                inverse.visible = true;
            }
        }
    }

    class Room
    {
        public string Description { get; set; }
        public string Name { get; set; }

        private Dictionary<Direction, RoomConnection> connections;

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            connections = new Dictionary<Direction, RoomConnection>();
        }

        public void ConnectTo(Room other, Direction to, Direction from, bool visible = true)
        {
            connections[to] = new RoomConnection(other, to, visible);
            other.connections[from] = new RoomConnection(this, from, visible) {
                inverse = connections[to],
            };
            connections[to].inverse = other.connections[from];
        }

        public RoomConnection GetConnected(Direction direction)
        {
            RoomConnection room;
            connections.TryGetValue(direction, out room);
            return room;
        }

        public IEnumerable<RoomConnection> GetVisibleConnections()
        {
            var list = new List<RoomConnection>();
            foreach(var connection in connections.Values)
            {
                if(connection.visible)
                {
                    list.Add(connection);
                }
            }
            return list;
        }

        public IEnumerable<RoomConnection> GetConnections()
        {
            return connections.Values;
        }
    }
}
