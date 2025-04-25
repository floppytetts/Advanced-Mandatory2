using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;

namespace GameFramework.Items
{
    /// <summary>
    /// A composite attack item made from multiple individual attack items.
    /// </summary>
    public class ComboAttackItem : IAttackItem
    {
        private readonly List<IAttackItem> _items = new();

        public ComboAttackItem(string name)
        {
            Name = name;
        }

        public void Add(IAttackItem item)
        {
            _items.Add(item);
            Logger.Info($"[Composite] Added {item.Name} to {Name}");
        }

        public string Name { get; }

        public int Hit => _items.Sum(i => i.Hit);
        public int Range => _items.Max(i => i.Range); // assume max range applies
    }
}
