using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class HomeController : Controller
{
    public IActionResult Index(string filtre)
    {
        var tumKullanicilar = UserData.Users.Keys.ToList();

        if (!string.IsNullOrWhiteSpace(filtre))
        {
            tumKullanicilar = tumKullanicilar
                .Where(k => k.ToLower().Contains(filtre.ToLower()))
                .ToList();
        }

        ViewBag.Users = tumKullanicilar;
        ViewBag.Filtre = filtre;

        return View();
    }

    public IActionResult Populer()
    {
        var populer = UserData.Users
            .SelectMany(kv => kv.Value)
            .GroupBy(k => k)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => new { Kullanici = g.Key, TakipciSayisi = g.Count() })
            .ToList();

        ViewBag.PopulerList = populer;
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
        ViewBag.Kullanici = kullanici;
        ViewBag.TakipEttikleri = set1;
        ViewBag.Takipciler = UserData.Users.Where(kv => kv.Value.Contains(hedef)).Select(kv => kv.Key).ToList();


        return View();
    }

    [HttpGet]
    public IActionResult KullaniciEkle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult KullaniciEkle(string KullaniciAdi, string Email)
    {
        if (!string.IsNullOrWhiteSpace(KullaniciAdi))
        {
            if (!UserData.Users.ContainsKey(KullaniciAdi))
            {
                UserData.Users[KullaniciAdi] = new HashSet<string>();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mesaj = $"{KullaniciAdi} zaten kayýtlý!";
            }
        }
        else
        {
            ViewBag.Mesaj = "Kullanýcý adý boþ olamaz.";
        }

        return View();
    }

    [HttpGet]
    public IActionResult Dashboard(string kullanici)
    {
        if (!UserData.Users.ContainsKey(kullanici))
            return RedirectToAction("Index");

        var takipEttikleri = UserData.Users[kullanici];
        var takipciler = UserData.Users.Where(kv => kv.Value.Contains(kullanici)).Select(kv => kv.Key).ToList();
        var ziyaretler = UserData.SonZiyaretler.ContainsKey(kullanici) ? UserData.SonZiyaretler[kullanici].ToList() : new List<string>();
        var onerilen = UserData.OnerilenTakip.ContainsKey(kullanici) ? UserData.OnerilenTakip[kullanici].ToList() : new List<string>();

        ViewBag.Kullanici = kullanici;
        ViewBag.TakipEttikleri = takipEttikleri;
        ViewBag.Takipciler = takipciler;
        ViewBag.Ziyaretler = ziyaretler;
        ViewBag.Oneriler = onerilen;

        return View();
    }

    [HttpPost]
    public IActionResult TakipEt(string takipeden, string takipedilen)
    {
        if (UserData.Users.ContainsKey(takipeden))
        {
            UserData.Users[takipeden].Add(takipedilen);
        }

        return RedirectToAction("Dashboard", new { kullanici = takipeden });
    }
}
