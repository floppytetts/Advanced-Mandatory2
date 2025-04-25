using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;

namespace GameFramework.Core
{
    /// <summary>
    /// Represents an object placed in the world, which may be lootable or removable.
    /// </summary>
    public class WorldObject
    {
        /// <summary>Name of the world object.</summary>
        public string Name { get; set; }

        /// <summary>Indicates whether the object can be looted.</summary>
        public bool Lootable { get; set; }

        /// <summary>Indicates whether the object can be removed from the world.</summary>
        public bool Removeable { get; set; }

        /// <summary>X position in the world.</summary>
        public int X { get; set; }

        /// <summary>Y position in the world.</summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the WorldObject class.
        /// </summary>
        
        public WorldObject(string name, bool lootable, bool removeable, int x = 0, int y = 0)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
            X = x;
            Y = y;
            Logger.Info($"World object {Name} created at position ({X}, {Y}). Lootable: {Lootable}, Removeable: {Removeable}");
        }
    }

}
