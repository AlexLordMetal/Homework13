using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class GameBattleModel
    {
        private Random random = new Random();

        public Player Player { get; set; }
        public Monster Monster { get; set; }
        public List<Item> Items { get; set; }
        public int Money { get; set; }
        public List<string> Report { get; set; }

        public bool StartBattle()
        {
            Report = new List<string>();
            while (Player.Hp > 0 && Monster.Hp > 0)
            {
                Attack(Player, Monster);
                if (Monster.Hp > 0) Attack(Monster, Player);
            }
            return Player.Hp > 0 ? true : false;
        }

        private void Attack(Creature attacker, Creature defender)
        {
            var damage = AttackPower(attacker);

            Report.Add($"{attacker.Name} attacks {defender.Name} with {damage} damage.");

            Defend(defender, damage);
        }

        private int AttackPower(Creature attacker)
        {
            return random.Next(attacker.Weapon.MinDamage, attacker.Weapon.MaxDamage + 1) + attacker.Str;
        }

        private void Defend(Creature defender, int damage)
        {
            defender.Hp -= damage;

            if (defender.Hp > 0)
            {
                Report.Add($"{defender.Name} has {defender.Hp} HP.");
            }
            else
            {
                Report.Add($"{defender.Name} died.");
            }
        }

    }
}