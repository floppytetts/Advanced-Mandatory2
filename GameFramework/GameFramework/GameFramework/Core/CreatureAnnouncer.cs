using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Logging;

namespace GameFramework.Core
{
    /// <summary>
    /// Announces hits to creatures using the observer pattern.
    /// </summary>
    public class CreatureAnnouncer : ICreatureObserver
    {
        public void OnCreatureHit(CreatureBase creature, int damage)
        {
            Logger.Info($"[Observer] {creature.Name} was hit for {damage} damage.");
        }
    }
}
