using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BattleASP.Models
{
    public class GameDbInitializer : DropCreateDatabaseIfModelChanges<GameDbContext>
    {
        protected override void Seed(GameDbContext context)
        {
            var random = new Random();

            var items = JsonParser.Items("~/Models/Items.json");
            var weapons = JsonParser.Weapons("~/Models/Weapons.json");
            var monsters = JsonParser.Monsters("~/Models/Monsters.json");

            foreach (var monster in monsters)
            {
                monster.StuffRandomizer(items, weapons, random);
            }

            context.Items.AddRange(items);
            context.Weapons.AddRange(weapons);
            context.Monsters.AddRange(monsters);
            base.Seed(context);
        }
    }
}