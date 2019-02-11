using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class Monster : Creature
    {

        public void StuffRandomizer(List<Item> items, List<Weapon> weapons, Random random)
        {
            var counter = random.Next(15, 25);
            for (int count = 0; count < counter; count++)
            {
                ItemsInventory.Add(items[random.Next(0, items.Count)]);
            }

            counter = random.Next(0, 6);
            for (int count = 0; count < counter; count++)
            {
                WeaponsInventory.Add(weapons[random.Next(0, weapons.Count)]);
            }
        }

    }
}