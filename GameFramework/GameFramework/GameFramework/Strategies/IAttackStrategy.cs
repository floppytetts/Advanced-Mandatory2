using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Strategies
{
    /// <summary>
    /// Interface for defining creature attack behavior.
    /// </summary>
    public interface IAttackStrategy
    {
        int CalculateDamage();
    }
}
