using System;

namespace BigGame_Console
{
    class ArmyManager
    {
        public static Warrior[] GetArmy(string armyString)
        {
            return CreateArmy(armyString.Split(','));
        }

        private static Warrior[] CreateArmy(string[] raceArmy)
        {
            var race = new Warrior[raceArmy.Length];

            WarriorListValidation(raceArmy);

            for (int i = 0; i < raceArmy.Length; i++)
                race[i] = new Warrior(raceArmy[i] == "S" ? WarriorType.Spearman : WarriorType.Bowman);
            return race;
        }
        private static void WarriorListValidation(string[] raceArmy)
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
    }
}
