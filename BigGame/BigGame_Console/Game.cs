using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame_Console
{
    class Game
    {
        public Warrior[] Army1 { get; set; }
        public Warrior[] Army2 { get; set; }
        public delegate void DShowArmy(Warrior[] orks, Warrior[] elfs);
        public event DShowArmy Notify;
        public void  Run(Warrior[] orks, Warrior[] elfs)
        {
            Notify?.Invoke(Army1, Army2);

            while (true)
            {
                Console.WriteLine($"\n\n{"Orks",30} attack!\n");
                Attack(elfs, orks);
                if (ArmyTotalHealth(elfs, orks) == 0)
                    break;

                Console.WriteLine($"\n\n{"Elfs",30} attack!\n");
                Attack(orks, elfs);
                if (ArmyTotalHealth(orks, elfs) == 0)
                    break;
            }
            Console.ReadKey();
        }
        public static (Warrior[] orks, Warrior[] elfs) GetArmies()
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
        public static Warrior[] CreateArmy(string[] raceArmy)
        {
            var race = new Warrior[raceArmy.Length];

            WarriorListValidation(raceArmy);

            for (int i = 0; i < raceArmy.Length; i++)
                race[i] = new Warrior(raceArmy[i] == "S" ? WarriorType.Spearman : WarriorType.Bowman);
            return race;
        }
        public static void WarriorListValidation(string[] raceArmy)
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
        public void Attack(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                if (attackingRace[i].HealthPoints > 0)
                    attackedRace[i].GetAttacked(attackingRace[i].DamageValue);
            Notify?.Invoke(Army1, Army2);
        }
        public static int ArmyTotalHealth(Warrior[] attackedRace, Warrior[] attackingRace)
        {
            int totalHealth = 0;
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                totalHealth += attackedRace[i].HealthPoints;
            return totalHealth;
        }
        public void ShowBattleField(Warrior[] orks, Warrior[] elfs)
        {
            ShowArmy("Orks:\t", orks);
            ShowArmy("Elfs:\t", elfs);
        }
        public static void ShowArmy(string raceName, Warrior[] race)
        {
            Console.Write(raceName);
            foreach (var warrior in race)
                Console.Write(warrior.ShowWarriorInfo());

            Console.WriteLine();
        }
        public static void PoraVMagez(string message)
        {
            Console.WriteLine(message);
        }

    }
}
