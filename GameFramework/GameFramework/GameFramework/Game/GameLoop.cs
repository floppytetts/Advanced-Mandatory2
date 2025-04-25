using System;
using System.Collections.Generic;
using GameFramework.Core;

namespace GameFramework
{
    /// <summary>
    /// Contains the main game loop where creatures take turns attacking each other.
    /// </summary>
    class GameLoop
    {
        /// <summary>
        /// Entry point of the application. Initializes creatures and starts the turn-based combat loop.
        /// </summary>
        static void Main()
        {
            var c1 = new Creature("Knight", 50);
            var c2 = new Creature("Orc", 40);

            var creatures = new List<Creature> { c1, c2 };
            var turnManager = new TurnManager(creatures);

            while (c1.HitPoint > 0 && c2.HitPoint > 0)
            {
                var current = turnManager.GetCurrentCreature();
                var target = current == c1 ? c2 : c1;

                Console.WriteLine($"{current.Name}'s turn to attack!");
                int damage = current.Hit();
                target.ReceiveHit(damage);

                turnManager.NextTurn();
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("Game over!");
        }
    }
}
