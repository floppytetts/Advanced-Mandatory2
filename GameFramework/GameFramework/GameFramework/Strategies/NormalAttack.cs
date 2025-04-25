using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Strategies
{
    /// <summary>
    /// Fixed-damage attack strategy.
    /// </summary>
    public class NormalAttack : IAttackStrategy
    {
        public int CalculateDamage() => 10;
    }
}
