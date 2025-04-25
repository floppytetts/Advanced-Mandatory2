using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;

namespace GameFramework.Items
{
    /// <summary>
    /// Decorator that boosts an attack item's hit value.
    /// </summary>
    public class BoostedAttackItem : IAttackItem
    {
        private readonly IAttackItem _baseItem;
        private readonly int _bonus;

        public BoostedAttackItem(IAttackItem baseItem, int bonus)
        {
            _baseItem = baseItem;
            _bonus = bonus;
            Logger.Info($"Boosted item created: {_baseItem.Name} +{_bonus} bonus hit.");
        }

        public string Name => _baseItem.Name + $" (+{_bonus})";
        public int Hit => _baseItem.Hit + _bonus;
        public int Range => _baseItem.Range;
    }
}
