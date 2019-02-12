using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class GameAdventureModel
    {
        public Player Player { get; set; }
        public List<Monster> Monsters { get; set; }
    }
}