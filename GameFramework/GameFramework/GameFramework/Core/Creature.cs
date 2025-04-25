using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Items;
using GameFramework.Logging;
using GameFramework.Strategies;
namespace GameFramework.Core
{
    /// <summary>
    /// Represents a creature in the game world, capable of moving, attacking, and looting objects.
    /// </summary>
    public class Creature : CreatureBase
    {
        public List<AttackItem> AttackItems { get; set; } = new();
        public List<DefenceItem> DefenceItems { get; set; } = new();

        public IAttackStrategy AttackStrategy { get; set; } = new NormalAttack();

        public Creature(string name, int hitPoint, int x = 0, int y = 0)
            : base(name, hitPoint, x, y) { }

        public int Hit() {
            return AttackStrategy.CalculateDamage();
        }
        public virtual void ReceiveHit(int damage)
{
    HitPoint -= damage;
    if (HitPoint < 0) HitPoint = 0;
    Logger.Info($"{Name} receives {damage} damage. Remaining HP: {HitPoint}");
}

        protected override void Move()
        {
            Logger.Info($"{Name} does not move.");
        }

        protected override void Attack(CreatureBase target)
        {
            int damage = Hit();
            target.ReceiveHit(damage);
            Logger.Info($"{Name} hits {target.Name} for {damage} damage.");
        }

       

        public void Loot(WorldObject obj)
        {
            if (obj is ILootable lootable)
            {
                lootable.OnLoot(this);
            }
            else
            {
                Logger.Info($"{obj.Name} is not lootable.");
            }
        }

        public void MoveTo(int x, int y)
        {
            Logger.Info($"{Name} moves from ({X}, {Y}) to ({x}, {y})");
            X = x;
            Y = y;
        }
    }

}
