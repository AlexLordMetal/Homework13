using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class Monster : Creature
    {
        private Random rnd = new Random();

        public void StuffRandomizer(List<Item> items, List<Weapon> weapons, Random random)
        {
            var counter = random.Next(15, 25);
            for (int count = 0; count < counter; count++)
            {
                Items.Add(items[random.Next(0, items.Count)]);
            }

            counter = random.Next(0, 6);
            for (int count = 0; count < counter; count++)
            {
                Items.Add(weapons[random.Next(0, weapons.Count)]);
            }
        }

        public int GetMoney()
        {
            return Level * rnd.Next(2, 6);
        }

        public List<Item> GetItems()
        {
            int counter = (int)(Level * (rnd.Next(0, 4) / 2.0));
            var loot = new List<Item>();
            for (int count = 0; count < counter; count++)
            {
                loot.Add(Items[rnd.Next(0, Items.Count)]);
            }
            return loot;
        }

    }
}