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

            var orks = new (Warrior warriorType, int healthPoints)[]
            {
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue)
            };

            var elfs = new (Warrior warriorType, int healthPoints)[]
            {
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Bowman, bowmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue),
                (Warrior.Spearman, spearmanHpValue)
            };

            //Console.WriteLine(orks[0]); //(Spearman, 11)
            //Console.WriteLine(orks[0].healthPoints); //11
            //orks[0].healthPoints = orks[0].healthPoints - spearmanDamageValue;
            //Console.WriteLine(orks[0].healthPoints); //8

            Console.Write("Орки:\t");
            foreach (var i in orks)
                ShowWarrior(i.warriorType, i.healthPoints);

            Console.Write("\nЭльфы:\t");
            foreach (var i in elfs)
                ShowWarrior(i.warriorType, i.healthPoints);

            Console.ReadKey();
        }

        static void ShowWarrior(Warrior warrior, int health)
        {
            if (warrior == Warrior.Spearman)
                Console.Write(String.Format("{0,3}{1,3}", "К(", $"{health})"));
            else
                Console.Write(String.Format("{0,3}{1,3}", "Л(", $"{health})"));
        }
    }
}