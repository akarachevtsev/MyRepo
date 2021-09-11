using System;
using System.IO;
using System.Collections.Generic;

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
            string path = @"D:\MyRepo\Army_list.txt";
            string[] fileContent = File.ReadAllLines(path);

            Game game = new Game(ArmyManager.GetArmy(fileContent[0].ToUpper()), ArmyManager.GetArmy(fileContent[1].ToUpper()));
            game.Notify += ShowBattleField;
            game.Run();
        }

        public static void ShowBattleField(List<Warrior> orks, List<Warrior> elfs)
        {
            ShowArmy("Orks:\t", orks);
            ShowArmy("Elfs:\t", elfs);
        }
        public static void ShowArmy(string raceName, List<Warrior> race)
        {
            Console.Write(raceName);
            foreach (var warrior in race)
                Console.Write(warrior.ShowWarriorInfo());
            Console.WriteLine();
        }
    }
}
