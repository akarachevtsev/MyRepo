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
                Console.WriteLine();
                Console.WriteLine("Orks attack!");
                for (int i = 0; i < orks.Length; i++)
                    Attack(orks[i].healthPoints, ref elfs[i].healthPoints, orks[i].damageValue);
                ShowArmy("Orks:\t", orks);
                ShowArmy("Elfs:\t", elfs);
                if (ArmyTotalHealth(elfs) == 0)
                    break;
                Console.WriteLine();
                Console.WriteLine("Elfs attack!");
                for (int i = 0; i < orks.Length; i++)
                    Attack(elfs[i].healthPoints, ref orks[i].healthPoints, elfs[i].damageValue);
                ShowArmy("Orks:\t", orks);
                ShowArmy("Elfs:\t", elfs);
                if (ArmyTotalHealth(orks) == 0)
                    break;
            }
            Console.ReadKey();
        }

        static void Attack(int attackingWarriorHealth,ref int attackedWarriorHealth, int attackingWarriorDamage)
        {
            if (attackingWarriorHealth > 0)
                attackedWarriorHealth = Math.Max(attackedWarriorHealth - attackingWarriorDamage, 0);
        }
        static int ArmyTotalHealth(params (Warrior warriorType, int healthPoints, int damageValue)[] race)
        {
            int totalHealth = 0;
            foreach (var i in race)
                totalHealth += i.healthPoints;
            return totalHealth;
        }
        static void ShowArmy(string raceName, params (Warrior warriorType, int healthPoints, int damageValue)[] race)
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