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

        public bool IfLvlUp()
        {
            var lvlUp = false;
            switch (Level)
            {
                case 1:
                    if (Exp >= 1000) { LvlUp(1000); lvlUp = true; }
                    break;
                case 2:
                    if (Exp >= 2000) { LvlUp(2000); lvlUp = true; }
                    break;
                case 3:
                    if (Exp >= 4000) { LvlUp(4000); lvlUp = true; }
                    break;
                case 4:
                    if (Exp >= 7000) { LvlUp(7000); lvlUp = true; }
                    break;
                case 5:
                    if (Exp >= 10000) { LvlUp(10000); lvlUp = true; }
                    break;
                case 6:
                    if (Exp >= 15000) { LvlUp(15000); lvlUp = true; }
                    break;
                default:
                    break;
            }
            if (lvlUp) IfLvlUp();
            return lvlUp;
        }

        private void LvlUp(int lvlExp)
        {
            Exp -= lvlExp;
            Level++;
            Hp += 5 * Level;
            Str += Level;
        }

    }

}