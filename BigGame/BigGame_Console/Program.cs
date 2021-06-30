using System;

namespace BigGame_Console
{
    enum Warrior
    {
        Spearman = 'К',
        Bowman = 'Л'
    }

    class Program
    {
        static void Main(string[] args)
        {

            Warrior[] orks = new Warrior[8] 
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

            Warrior[] elfs = new Warrior[10]
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
            for (int i = 0; i < orks.Length; i++)
            {
                Console.Write($" {(char)orks[i]}");
            }
            
            Console.Write("\nЭльфы:\t");
            for (int i = 0; i < elfs.Length; i++)
            {
                Console.Write($" {(char)elfs[i]}");
            }

            Console.ReadKey();
        }
    }
}