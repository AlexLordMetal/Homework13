using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class Item : BaseClass
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        public virtual List<Monster> Monsters { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}