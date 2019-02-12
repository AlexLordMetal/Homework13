using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BattleASP.Models;

namespace BattleASP.Controllers
{
    public class GameController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Game
        public ActionResult Tavern()
        {
            var id = Session["playerId"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        public ActionResult Adventure()
        {            
            var id = Session["playerId"];
            var adventureModel = new GameAdventureModel();
            adventureModel.Player = db.Players.Find(id);
            adventureModel.Monsters = db.Monsters.OrderBy(x => x.Level).ToList();
            return View(adventureModel);
        }

        public ActionResult BattleResult(int? id)
        {
            var battleModel = new GameBattleModel();
            battleModel.Items = new List<Item>();
            battleModel.Player = db.Players.Find(Session["playerId"]);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            battleModel.Monster = db.Monsters.Find(id);
            if (battleModel.Monster == null)
            {
                return HttpNotFound();
            }
            var playerStartHp = battleModel.Player.Hp;
            var monsterStartHp = battleModel.Monster.Hp;

            if (battleModel.StartBattle())
            {
                battleModel.Player.Hp = playerStartHp;
                battleModel.Monster.Hp = monsterStartHp;
                YouWon(battleModel);
                return View("YouWon", battleModel);
            }
            else
            {
                battleModel.Monster.Hp = monsterStartHp;
                return View("YouLose", battleModel.Report);
            }
        }

        public void YouWon(GameBattleModel battleModel)
        {
            battleModel.Money = battleModel.Monster.GetMoney();
            battleModel.Items = battleModel.Monster.GetItems();

            battleModel.Player.Money += battleModel.Money;
            battleModel.Player.Items.AddRange(battleModel.Items);

            battleModel.Player.Exp += battleModel.Monster.Level * 100;
            battleModel.Player.IfLvlUp();
        }


    }
}