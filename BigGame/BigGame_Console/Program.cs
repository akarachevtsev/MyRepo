using System;
using System.IO;

namespace BigGame_Console
{
    enum WarriorType
    {
        Spearman,
        Bowman
    }
    class Program
    {
        static void Main(string[] args)
        {
            var armies = GetArmies();
            var orks = armies.orks;
            var elfs = armies.elfs;

            ShowBattleField(orks, elfs);

            while (true)
            {
                Console.WriteLine($"\n\n{"Orks",30} attack!\n");
                Attack(elfs, orks);
                ShowBattleField(orks, elfs);
                if (ArmyTotalHealth(elfs, orks) == 0)
                    break;

                Console.WriteLine($"\n\n{"Elfs",30} attack!\n");
                Attack(orks, elfs);
                ShowBattleField(orks, elfs);
                if (ArmyTotalHealth(orks, elfs) == 0)
                    break;
            }
            Console.ReadKey();
        }
        static (Warrior[] orks, Warrior[] elfs) GetArmies()
        {
            string path = @"D:\MyRepo\Army_list.txt";
            string[] fileContent = File.ReadAllLines(path);
            string[] orksArmy = fileContent[0].Split(',');
            string[] elfsArmy = fileContent[1].Split(',');

            var orks = CreateArmy(orksArmy);
            var elfs = CreateArmy(elfsArmy);
            var armies = (orks, elfs);
            return armies;
        }
        static Warrior[] CreateArmy(string[] raceArmy)
        {
            var race = new Warrior[raceArmy.Length];

            WarriorListValidation(raceArmy);

            for (int i = 0; i < raceArmy.Length; i++)
                race[i] = new Warrior(raceArmy[i] == "S" ? WarriorType.Spearman : WarriorType.Bowman);
            return race;
        }
        static void WarriorListValidation(string[] raceArmy)
        {
            foreach (string i in raceArmy)
            {
                if (i != "S" & i != "B")
                {
                    Console.WriteLine("Wrong warrior char in army list");
                    Environment.Exit(0);
                }
            }
        }
        static void Attack(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                if (attackingRace[i].HealthPoints > 0)
                    attackedRace[i].GetAttacked(attackingRace[i].DamageValue);        
        }
        static int ArmyTotalHealth(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int totalHealth = 0;
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                totalHealth += attackedRace[i].HealthPoints;
            return totalHealth;
        }
        static void ShowBattleField(Warrior[] orks, Warrior[] elfs)
        {
            ShowArmy("Orks:\t", orks);
            ShowArmy("Elfs:\t", elfs);
        }
        static void ShowArmy(string raceName, Warrior[] race)
        {
            Console.Write(raceName);
            foreach (var warrior in race)
            Console.Write(warrior.ShowWarriorInfo());

            Console.WriteLine();
        }
    }
}