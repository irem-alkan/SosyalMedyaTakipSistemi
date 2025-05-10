using Microsoft.AspNetCore.Mvc;
using SosyalMedyaTakipSistemi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SosyalMedyaTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var users = UserData.Users.Keys.ToList();
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public IActionResult Compare(string user1, string user2)
        {
            var set1 = UserData.Users.ContainsKey(user1) ? UserData.Users[user1] : new HashSet<string>();
            var set2 = UserData.Users.ContainsKey(user2) ? UserData.Users[user2] : new HashSet<string>();

            ViewBag.User1 = user1;
            ViewBag.User2 = user2;
            ViewBag.Ortak = set1.Intersect(set2).ToList();
            ViewBag.Birlesim = set1.Union(set2).ToList();
            ViewBag.Fark = set1.Except(set2).ToList();

            return View();
        }
    }
}