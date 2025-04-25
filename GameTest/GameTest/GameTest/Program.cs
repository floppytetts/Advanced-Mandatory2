using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameFramework.Config;
using GameFramework.Core;
using GameFramework.Items;
using GameFramework.Logging;
using GameFramework.Strategies;

class Program
{
    static void Main()
    {
        // Generate timestamped log file
        string timestamp = DateTime.Now.ToString("dd_MM_yy_HHmmss");
        string logFileName = $"log_{timestamp}.txt";

        // Setup logging to console + file
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new TextWriterTraceListener(logFileName));
        Trace.AutoFlush = true;
        Trace.WriteLine("=== Game Started ===");

        // Load config values from XML (Dependency Inversion + XML config demo)
        var config = ConfigManager.LoadConfig("gameconfig.xml");
        World world = new World(config);

        // Create two creatures for battle
        Creature hero = new Creature("Hero", 100, 6, 9);
        Creature goblin = new Creature("Goblin", 30, 5, 6);

        // --- Decorator Pattern Demo ---
        var baseSword = new AttackItem("Iron Sword", 10, 1);
        var boostedSword = new BoostedAttackItem(baseSword, 5);
        Logger.Info($"[Decorator Demo] Base sword hit: {baseSword.Hit}, Boosted sword hit: {boostedSword.Hit}");

        // --- Composite Pattern Demo ---
        var fire = new AttackItem("Fire Enchantment", 5, 1);
        var poison = new AttackItem("Poison Coating", 3, 1);
        var combo = new ComboAttackItem("Flaming Poison Blade");
        combo.Add(baseSword);
        combo.Add(fire);
        combo.Add(poison);
        Logger.Info($"[Composite Demo] {combo.Name} total hit: {combo.Hit}, range: {combo.Range}");

        // --- Strategy Pattern Demo ---
        hero.AttackStrategy = new NormalAttack();   // Fixed damage
        goblin.AttackStrategy = new RandomAttack(); // Randomized damage
        Logger.Info($"[Strategy Demo] Hero uses fixed damage. Goblin uses random damage.");

        // --- Liskov Substitution Demo ---
        List<WorldObject> lootables = new List<WorldObject>
        {
            new AttackItem("Rusty Axe", 12, 1),
            new DefenceItem("Old Shield", 3)
        };

        foreach (var obj in lootables)
        {
            Trace.WriteLine($"[Liskov Demo] {obj.Name} is a {obj.GetType().Name} and is located at ({obj.X},{obj.Y})");
        }

        // Add creatures to turn manager
        var creatures = new List<Creature> { hero, goblin };
        var turnManager = new TurnManager(creatures);

        // Place some lootable objects in the world
        WorldObject chest = new WorldObject("Treasure Chest", true, false, 2, 3);
        WorldObject cake = new WorldObject("Super-Cupcake", true, false, 6, 9);
        var worldObjects = new List<WorldObject> { chest, cake };

        // Try looting objects (Single Responsibility, Loot logic)
        foreach (var obj in worldObjects)
        {
            if (hero.X == obj.X && hero.Y == obj.Y)
            {
                hero.Loot(obj);
            }
            else
            {
                Logger.Info($"{hero.Name} is not at the same position as {obj.Name}, cannot loot.");
            }
        }

        // --- Observer Pattern Demo ---
        CreatureAnnouncer announcer = new();
        hero.AddObserver(announcer);
        goblin.AddObserver(announcer);

        // --- Fight Loop (Template in action) ---
        while (hero.HitPoint > 0 && goblin.HitPoint > 0)
        {
            var current = turnManager.GetCurrentCreature();
            var target = current == hero ? goblin : hero;

            Trace.WriteLine($"{current.Name}'s turn to attack!");
            int damage = current.Hit();  // Uses Strategy pattern
            target.ReceiveHit(damage);   // Triggers Observer

            turnManager.NextTurn();
            System.Threading.Thread.Sleep(1000); // Add pause for readability
        }

        // Use LINQ to find dead creatures
        var deadCreatures = creatures.Where(c => !c.IsAlive).ToList();
        foreach (var dead in deadCreatures)
        {
            Trace.WriteLine($"{dead.Name} has died.");
        }

        Trace.WriteLine("=== Game Ended ===");
    }
}
