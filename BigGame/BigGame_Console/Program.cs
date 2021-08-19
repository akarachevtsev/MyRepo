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
            var armies = Game.GetArmies();
            Game game = new Game();
            game.Army1 = armies.orks;
            game.Army2 = armies.elfs;
            game.Notify += game.ShowBattleField;
            game.Run(game.Army1, game.Army2);
        }
    }
}
