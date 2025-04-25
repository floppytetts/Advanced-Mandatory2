using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Core
{
    /// <summary>
    /// Defines an observer that reacts when a creature is hit.
    /// </summary>
    public interface ICreatureObserver
    {
        void OnCreatureHit(CreatureBase creature, int damage);
    }
}
