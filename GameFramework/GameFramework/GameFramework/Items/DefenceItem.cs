using GameFramework.Core;
using GameFramework.Logging;

namespace GameFramework.Items
{
    /// <summary>
    /// Represents a defence item (e.g., shield, boots) that reduces incoming damage.
    /// </summary>
    public class DefenceItem : WorldObject, ILootable
    {
        /// <summary>Amount of damage this item reduces when equipped.</summary>
        public int ReduceHitPoint { get; set; }

        /// <summary>
        /// Initializes a new instance of the DefenceItem class.
        /// </summary>
        /// <param name="name">Name of the defence item.</param>
        /// <param name="reduceHitPoint">Amount of damage reduced.</param>
        /// <param name="x">X position in the world.</param>
        /// <param name="y">Y position in the world.</param>
        public DefenceItem(string name, int reduceHitPoint, int x = 0, int y = 0)
            : base(name, lootable: true, removeable: true, x, y)
        {
            ReduceHitPoint = reduceHitPoint;
            Logger.Info($"Defence item {Name} created with {ReduceHitPoint} hit points reduction.");
        }
        public void OnLoot(Creature looter)
        {
            looter.DefenceItems.Add(this);
            Logger.Info($"{looter.Name} loots defence item: {Name}");
        }
    }

}
