using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;

namespace GameFramework.Core
{
    /// <summary>
    /// Base class for creatures using the Template Method pattern.
    /// </summary>
    public abstract class CreatureBase
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsAlive => HitPoint > 0;

        public CreatureBase(string name, int hitPoint, int x = 0, int y = 0)
        {
            Name = name;
            HitPoint = hitPoint;
            X = x;
            Y = y;
            Logger.Info($"{Name} (base) spawned at ({X},{Y}) with {HitPoint} HP");
        }

        /// <summary>
        /// Template method for taking a turn.
        /// </summary>
        public void TakeTurn(CreatureBase target)
        {
            Logger.Info($"{Name} begins turn.");
            Move();
            Attack(target);
        }
        public virtual void ReceiveHit(int damage)
        {
            HitPoint -= damage;
            if (HitPoint < 0) HitPoint = 0;
            Logger.Info($"{Name} receives {damage} damage. Remaining HP: {HitPoint}");

            // Notify all observers
            foreach (var observer in _observers)
            {
                observer.OnCreatureHit(this, damage);
            }
        }


        protected abstract void Move();
        protected abstract void Attack(CreatureBase target);

        private readonly List<ICreatureObserver> _observers = new();

        /// <summary>
        /// Adds an observer to be notified when this creature is hit.
        /// </summary>
        public void AddObserver(ICreatureObserver observer)
        {
            _observers.Add(observer);
        }

    }
}
