using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Users = UserData.Users.Keys.ToList();
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

    public IActionResult ProfilGoruntule(string kullanici, string hedef)
    {
        if (!UserData.SonZiyaretler.ContainsKey(kullanici))
            UserData.SonZiyaretler[kullanici] = new Queue<string>();

        var kuyruk = UserData.SonZiyaretler[kullanici];
        if (kuyruk.Count >= 5) kuyruk.Dequeue();
        kuyruk.Enqueue(hedef);

        var set1 = UserData.Users.ContainsKey(kullanici) ? UserData.Users[kullanici] : new HashSet<string>();
        var set2 = UserData.Users.ContainsKey(hedef) ? UserData.Users[hedef] : new HashSet<string>();
        var oneri = set2.Except(set1);

        UserData.OnerilenTakip[kullanici] = new LinkedList<string>(oneri);

        ViewBag.Ziyaretler = kuyruk.ToList();
        ViewBag.Oneriler = oneri.ToList();

        return View();
    }
}
