using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Items
{
    /// <summary>
    /// Interface representing an attack-capable item.
    /// </summary>
    public interface IAttackItem
    {
        string Name { get; }
        int Hit { get; }
        int Range { get; }
    }
}
