using System;
using System.Collections.Generic;

namespace GameFramework.Core
{
    /// <summary>
    /// Manages turn-based logic for a list of creatures.
    /// </summary>
    public class TurnManager
    {
        private readonly List<Creature> _creatures;
        private int _currentIndex = 0;

        /// <summary>
        /// Initializes a new instance of the TurnManager class.
        /// </summary>
        /// <param name="creatures">The list of creatures taking turns.</param>
        public TurnManager(List<Creature> creatures)
        {
            _creatures = creatures;
        }

        /// <summary>
        /// Gets the creature whose turn it currently is.
        /// </summary>
        /// <returns>The active creature.</returns>
        public Creature GetCurrentCreature()
        {
            return _creatures[_currentIndex];
        }

        /// <summary>
        /// Advances the turn to the next creature in the list.
        /// </summary>
        public void NextTurn()
        {
            _currentIndex = (_currentIndex + 1) % _creatures.Count;
        }
    }
}
