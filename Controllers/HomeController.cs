using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        forumverileriEntities db = new forumverileriEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.forumtablosu.ToList();
            return View(data);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Tables()
        {
            var data = db.forumtablosu.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(string Arama)
        {

            var data = db.forumtablosu.Where(p => p.isim.Contains(Arama) || p.soyisim.Contains(Arama)).ToList();

            return View(data);
        }
        [HttpPost]
        public ActionResult Tables(string Arama)
        {

            var data = db.forumtablosu.Where(p => p.isim.Contains(Arama) || p.soyisim.Contains(Arama)).ToList();

            return View(data);
        }



        public ActionResult Sil(int id)
        {
            var urun = db.forumtablosu.Find(id);
            db.forumtablosu.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Tables");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(forumtablosu s1)
        {
            var urunler = db.forumtablosu.Add(s1);
            db.SaveChanges();

            return View();
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(forumtablosu p1)
        {

            var personel = db.forumtablosu.Find(p1.id);
            personel.isim = p1.isim;
            personel.soyisim = p1.soyisim;
            personel.mesaj = p1.mesaj;
            personel.tarih = p1.tarih;
            db.SaveChanges();

            return RedirectToAction("Tables");
        }




    }
}