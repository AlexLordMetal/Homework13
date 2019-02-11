using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class Creature : BaseClass
    {
        private int hp;

        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (value >= 0)
                {
                    hp = value;
                }
                else
                {
                    hp = 0;
                }
            }
        }
        public int Mp { get; set; }
        public int Str { get; set; }
        public int Int { get; set; }
        public Weapon Weapon { get; set; }
        public virtual List<Item> ItemsInventory { get; set; }
        public virtual List<Weapon> WeaponsInventory { get; set; }
    }
}