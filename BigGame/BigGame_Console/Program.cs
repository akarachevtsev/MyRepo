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

            Warrior[] orks = new[]
            {
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Bowman
            };

            Warrior[] elfs = new []
            {
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Bowman,
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Spearman,
                Warrior.Spearman
            };

            Console.Write("Орки:\t");
            foreach (Warrior i in orks)
                ShowWarrior(i);

            Console.Write("\nЭльфы:\t");
            foreach (Warrior i in elfs)
                ShowWarrior(i);

            Console.ReadKey();
        }

        static void ShowWarrior(Warrior i)
        {
            if (i == Warrior.Spearman)
                Console.Write(" К");
            else
                Console.Write(" Л");
        }
    }
}