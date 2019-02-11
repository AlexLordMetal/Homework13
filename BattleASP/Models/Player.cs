using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class Player : Creature
    {
        public int Exp { get; set; }
        public int Money { get; set; }

        public void StartParams()
        {
            var fists = new Weapon()
            {
                Name = "Fists",
                Weight = 0,
                Cost = 0,
                MinDamage = 1,
                MaxDamage = 2
            };

            Hp = 20;
            Mp = 0;
            Str = 1;
            Int = 1;
            Level = 1;
            Exp = 0;
            Money = 0;
            Weapon = fists;
        }
    }

}