using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BattleASP.Models
{
    public static class JsonParser
    {
        public static List<Item> Items(string file)
        {
            file = HostingEnvironment.MapPath(file);
            var items = new List<Item>();
            if (File.Exists(file))
            {
                using (var readFile = new StreamReader(file))
                {
                    items = JsonConvert.DeserializeObject<List<Item>>(readFile.ReadLine());
                }
            }
            return items;
        }

        public static List<Weapon> Weapons(string file)
        {
            file = HostingEnvironment.MapPath(file);
            var weapons = new List<Weapon>();
            if (File.Exists(file))
            {
                using (var readFile = new StreamReader(file))
                {
                    weapons = JsonConvert.DeserializeObject<List<Weapon>>(readFile.ReadLine());
                }
            }
            return weapons;
        }

        public static List<Monster> Monsters(string file)
        {
            file = HostingEnvironment.MapPath(file);
            var monsters = new List<Monster>();
            if (File.Exists(file))
            {
                using (var readFile = new StreamReader(file))
                {
                    monsters = JsonConvert.DeserializeObject<List<Monster>>(readFile.ReadLine());
                }
            }
            return monsters;
        }
    }
}