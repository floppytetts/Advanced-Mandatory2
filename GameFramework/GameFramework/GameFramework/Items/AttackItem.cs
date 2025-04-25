using GameFramework.Core;
using GameFramework.Logging;

namespace GameFramework.Items
{
    /// <summary>
    /// Represents an attack item (e.g., weapon or magic) that can deal damage to creatures.
    /// </summary>
    public class AttackItem : WorldObject, ILootable, IAttackItem
    {
        /// <summary>Amount of damage the item can deal.</summary>
        public int Hit { get; set; }

        /// <summary>The range of the attack (in tiles or units).</summary>
        public int Range { get; set; }

        /// <summary>
        /// Initializes a new instance of the AttackItem class.
        /// </summary>
        /// <param name="name">Name of the attack item.</param>
        /// <param name="hit">Damage dealt by the item.</param>
        /// <param name="range">Range of the attack.</param>
        /// <param name="x">X position in the world.</param>
        /// <param name="y">Y position in the world.</param>
        public AttackItem(string name, int hit, int range, int x = 0, int y = 0)
            : base(name, lootable: true, removeable: true, x, y)
        {
            Hit = hit;
            Range = range;
            Logger.Info($"Attack item {Name} created with {Hit} hit points and {Range} range.");
        }
        public void OnLoot(Creature looter)
        {
            looter.AttackItems.Add(this);
            Logger.Info($"{looter.Name} loots attack item: {Name}");
        }
    }

}
