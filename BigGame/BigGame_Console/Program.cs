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
            var orks = GetOrksArmie(spearmanHpValue, spearmanDamageValue, bowmanHpValue, bowmanDamageValue);
            var elfs = GetElfsArmie(spearmanHpValue, spearmanDamageValue, bowmanHpValue, bowmanDamageValue);
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
        static (Warrior warriorType, int healthPoints, int damageValue)[] GetElfsArmie(int spearmanHpValue, int spearmanDamageValue, int bowmanHpValue, int bowmanDamageValue)
        {
            var elfs = new (Warrior warriorType, int healthPoints, int damageValue)[]
            {
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Bowman, bowmanHpValue, bowmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue),
                (Warrior.Spearman, spearmanHpValue, spearmanDamageValue)
            };
            return elfs;
        }
        static (Warrior warriorType, int healthPoints, int damageValue)[] GetOrksArmie(int spearmanHpValue, int spearmanDamageValue, int bowmanHpValue, int bowmanDamageValue)
        {
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
            return orks;
        }
        static void Attack((Warrior warriorType, int healthPoints, int damageValue)[] attackedRace, (Warrior warriorType, int healthPoints, int damageValue)[] attackingRace)
        {
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                if (attackingRace[i].healthPoints > 0)
                    attackedRace[i].healthPoints = Math.Max(attackedRace[i].healthPoints - attackingRace[i].damageValue, 0);
        }
        static int ArmyTotalHealth((Warrior warriorType, int healthPoints, int damageValue)[] attackedRace, (Warrior warriorType, int healthPoints, int damageValue)[] attackingRace)
        {
            int totalHealth = 0;
            int minArmyLenght = Math.Min(attackedRace.Length, attackingRace.Length);
            for (int i = 0; i < minArmyLenght; i++)
                totalHealth += attackedRace[i].healthPoints;
            return totalHealth;
        }
        static void ShowBattleField((Warrior warriorType, int healthPoints, int damageValue)[] orks, (Warrior warriorType, int healthPoints, int damageValue)[] elfs)
        {
            ShowArmy("Orks:\t", orks);
            ShowArmy("Elfs:\t", elfs);
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
            string warriorChar = warrior == Warrior.Spearman ? "S" : "B";
            Console.Write($" {warriorChar}({health,2})");
        }
    }
}