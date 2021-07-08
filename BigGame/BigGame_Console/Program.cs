using System;

namespace BigGame_Console
{
    enum Warrior
    {
        Spearman,
        Bowman
    }

    class Program
    {
        static void Main(string[] args)
        {
            int spearmanDamageValue = 3;
            int bowmanDamageValue = 5;
            int spearmanHpValue = 11;
            int bowmanHpValue = 7;

            var orks = new (Warrior warriorType, int healthPoints, int damageValue)[]
            {
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue)
            };

            var elfs = new (Warrior warriorType, int healthPoints, int damageValue)[]
            {
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue)
                //(Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                //(Warrior.Spearman, spearmanHpValue, spearmanDamageValue)
            };

            ShowArmy("Orks:\t", orks);
            ShowArmy("Elfs:\t", elfs);

            while (true)
            {
                OrksAttack(elfs, orks);
                if (ArmyTotalHealth(elfs) == 0)
                    break;

                ElfsAttack(orks, elfs);
                if (ArmyTotalHealth(orks) == 0)
                    break;
            }
            Console.ReadKey();
        }
        static void OrksAttack((Warrior warriorType, int healthPoints, int damageValue)[] attackedRace, (Warrior warriorType, int healthPoints, int damageValue)[] attackingRace)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{"Orks",30} attack!");
            Console.WriteLine();
            for (int i = 0; i < attackingRace.Length; i++)
                if (attackingRace[i].healthPoints > 0)
                    attackedRace[i].healthPoints = Math.Max(attackedRace[i].healthPoints - attackingRace[i].damageValue, 0);
            ShowArmy("Orks:\t", attackingRace);
            ShowArmy("Elfs:\t", attackedRace);
        }

        static void ElfsAttack((Warrior warriorType, int healthPoints, int damageValue)[] attackedRace, (Warrior warriorType, int healthPoints, int damageValue)[] attackingRace)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{"Elfs",30} attack!");
            Console.WriteLine();
            for (int i = 0; i < attackedRace.Length; i++)
                if (attackingRace[i].healthPoints > 0)
                    attackedRace[i].healthPoints = Math.Max(attackedRace[i].healthPoints - attackingRace[i].damageValue, 0);
            ShowArmy("Orks:\t", attackedRace);
            ShowArmy("Elfs:\t", attackingRace);
        }


        static int ArmyTotalHealth((Warrior warriorType, int healthPoints, int damageValue)[] race)
        {
            int totalHealth = 0;
            foreach (var i in race)
                totalHealth += i.healthPoints;
            return totalHealth;
        }
        static void ShowArmy(string raceName, (Warrior warriorType, int healthPoints, int damageValue)[] race)
        {
            Console.Write(raceName);
            foreach (var i in race)
                ShowWarrior(i.warriorType, i.healthPoints);
            Console.WriteLine();
        }
        static void ShowWarrior(Warrior warrior, int health)
        {
            string warriorChar = warrior == Warrior.Spearman ? "К" : "Л";
            Console.Write($" {warriorChar}({health,2})");
        }
    }
}