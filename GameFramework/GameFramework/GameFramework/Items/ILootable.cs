using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;

namespace GameFramework.Items
{
    /// <summary>
    /// Interface for objects that can be looted by creatures.
    /// </summary>
    public interface ILootable
    {
        void OnLoot(Creature looter);
    }
}
