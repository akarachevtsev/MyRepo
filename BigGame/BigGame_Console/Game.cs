using System;

namespace BigGame_Console
{
    class Game
    {
        private readonly Warrior[] _armyOfOrks;
        private readonly Warrior[] _armyOfElfs;

        public Game(Warrior[] orks, Warrior[] elfs)
        {
            _armyOfOrks = orks;
            _armyOfElfs = elfs;
        }

        public delegate void DShowArmy(Warrior[] orks, Warrior[] elfs);
        public event DShowArmy Notify;
        public void  Run()
        {
            Notify?.Invoke(_armyOfOrks, _armyOfElfs);

            while (true)
            {
                Console.WriteLine($"\n\n{"Orks",30} attack!\n");
                Attack(_armyOfElfs, _armyOfOrks);
                if (ArmyTotalHealth(_armyOfElfs, _armyOfOrks) == 0)
                    break;

                Console.WriteLine($"\n\n{"Elfs",30} attack!\n");
                Attack(_armyOfOrks, _armyOfElfs);
                if (ArmyTotalHealth(_armyOfOrks, _armyOfElfs) == 0)
                    break;
            }
            Console.ReadKey();
        }
        private void Attack(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int minArmyLength = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLength; i++)
                if (attackingRace[i].HealthPoints > 0)
                    attackedRace[i].GetAttacked(attackingRace[i].DamageValue);
            Notify?.Invoke(_armyOfOrks, _armyOfElfs);
        }
        private static int ArmyTotalHealth(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int totalHealth = 0;
            int minArmyLength = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLength; i++)
                totalHealth += attackedRace[i].HealthPoints;
            return totalHealth;
        }
    }
}
