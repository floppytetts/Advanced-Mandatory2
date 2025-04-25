using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Strategies
{
    /// <summary>
    /// Random damage strategy between 5 and 15.
    /// </summary>
    public class RandomAttack : IAttackStrategy
    {
        private static readonly Random _rand = new();

        public int CalculateDamage() => _rand.Next(5, 16);
    }
}
