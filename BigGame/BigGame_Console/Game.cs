using System;
using System.Collections.Generic;

namespace BigGame_Console
{
    class Game
    {
        private readonly List<Warrior> _armyOfOrks;
        private readonly List<Warrior> _armyOfElfs;

        public Game(List<Warrior> orks, List<Warrior> elfs)
        {
            _armyOfOrks = orks;
            _armyOfElfs = elfs;
        }

        public delegate void DShowArmy(List<Warrior> orks, List<Warrior> elfs);
        public event DShowArmy Notify;
        public void  Run()
        {
            Notify?.Invoke(_armyOfOrks, _armyOfElfs);

            while (true)
            {
                Console.WriteLine($"\n\n{"Orks",30} attack!\n");
                Attack(_armyOfElfs, _armyOfOrks);
                if (_armyOfElfs.Count == 0)
                {
                    Console.WriteLine($"\n\n{"Orks",30} win!\n");
                    break;
                }

                Console.WriteLine($"\n\n{"Elfs",30} attack!\n");
                Attack(_armyOfOrks, _armyOfElfs);
                if (_armyOfOrks.Count == 0)
                {
                    Console.WriteLine($"\n\n{"Elfs",30} win!\n");
                    break;
                }
            }
            Console.ReadKey();
        }
        private void Attack(List<Warrior> attackedRace, List<Warrior> attackingRace)
        {
            int minArmyLength = Math.Min(attackedRace.Count, attackingRace.Count);
            for (int i = 0; i < minArmyLength; i++)
                if (attackingRace[i].HealthPoints > 0)
                    attackedRace[i].GetAttacked(attackingRace[i].DamageValue);
            ArmyHealthChecker(attackedRace);
            Notify?.Invoke(_armyOfOrks, _armyOfElfs);
        }
        private static void ArmyHealthChecker(List<Warrior> attackedRace)
        {
            for (int warrior = attackedRace.Count-1; warrior >= 0; warrior--)
            {
                if (attackedRace[warrior].HealthPoints == 0)
                    attackedRace.Remove(attackedRace[warrior]);
            }
        }
    }
}
