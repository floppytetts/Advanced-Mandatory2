using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;
using GameFramework.Config;

namespace GameFramework.Core
{
    /// <summary>
    /// Represents the game world with defined boundaries and containing creatures and objects.
    /// </summary>
    public class World
    {
        /// <summary>The maximum X coordinate of the world.</summary>
        public int MaxX { get; set; }

        /// <summary>The maximum Y coordinate of the world.</summary>
        public int MaxY { get; set; }

        /// <summary>List of creatures in the world.</summary>
        public List<Creature> Creatures { get; set; } = new();

        /// <summary>List of objects placed in the world.</summary>
        public List<WorldObject> Objects { get; set; } = new();

      

        /// <summary>
        /// Initializes a new instance of the World class using configuration settings.
        /// </summary>
        /// <param name="settings">Game settings containing world size.</param>
        public World(GameSettings settings)
        {
            MaxX = settings.World.MaxX;
            MaxY = settings.World.MaxY;
            Logger.Info($"World created with size: {MaxX}x{MaxY}");
        }
    }

}
