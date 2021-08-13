using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame_Console
{
    class Warrior
    {
        const int spearmanDamageValue = 3;
        const int bowmanDamageValue = 5;
        const int spearmanHpValue = 11;
        const int bowmanHpValue = 7;

        public int HealthPoints { get; set; }
        public int DamageValue { get; set; }
        public WarriorType WarriorType { get; set; }
        public Warrior(WarriorType warriorType)
        {
            WarriorType = warriorType;
            HealthPoints = WarriorType == WarriorType.Bowman ? bowmanHpValue : spearmanHpValue;
            DamageValue = WarriorType == WarriorType.Bowman ? bowmanDamageValue : spearmanDamageValue;
        }
        public string ShowWarriorInfo()
        {
            string warriorChar = WarriorType == WarriorType.Spearman ? "S" : "B";
             return $" {warriorChar}({HealthPoints,2})";
        }
        public void GetAttacked(int damageValue)
        {
            HealthPoints = Math.Max(HealthPoints - damageValue, 0);
        }
    }
}
