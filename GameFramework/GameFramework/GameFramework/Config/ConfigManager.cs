using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace GameFramework.Config
{
    /// <summary>
    /// Contains configuration data for the game.
    /// </summary>
    [XmlRoot("GameSettings")]
    public class GameSettings
    {
        /// <summary>Settings related to the world.</summary>
        public WorldSettings World { get; set; }

        /// <summary>Settings related to the game level.</summary>
        public GameLevelSettings Game { get; set; }
    }

    /// <summary>
    /// Defines the size of the world.
    /// </summary>
    public class WorldSettings
    {
        /// <summary>Maximum X value of the world.</summary>
        public int MaxX { get; set; }

        /// <summary>Maximum Y value of the world.</summary>
        public int MaxY { get; set; }
    }

    /// <summary>
    /// Defines the game difficulty level.
    /// </summary>
    public class GameLevelSettings
    {
        /// <summary>The selected level (e.g., Novice, Normal, Trained).</summary>
        public string Level { get; set; }
    }

    /// <summary>
    /// Loads and provides access to the game's configuration settings.
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// Loads the configuration from an XML file.
        /// </summary>
        /// <param name="path">Path to the config file.</param>
        /// <returns>Deserialized GameSettings object.</returns>
        public static GameSettings LoadConfig(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (GameSettings)serializer.Deserialize(fs);
            }
        }
    }

}

