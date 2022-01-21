using Deneme.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var veri = context.ogrencis.Select(i => new OgrencıModel()
            {
                Ad = i.Ad,
                Soyad = i.Soyad,
                Numara = i.Numara,
                BolumAd = i.Bolum.BolumAd
            }).ToList();
            return View(veri);
        }
        public IActionResult Ekleme()
        {
            List<SelectListItem> degerler = (from i in context.bolums.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.BolumAd,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult Ekleme(Ogrenci datas)
        {

            //var bolid = context.bolums.Where(m => m.Id == datas.Bolum.Id).FirstOrDefault();
            datas.BolumId = datas.Bolum.Id;
            datas.Numara = numaraVer();
            datas.Bolum = null; //hata sonucu yazıldı

            context.ogrencis.Add(datas);
            context.SaveChanges();
            return RedirectToAction("index");

        }
        public int numaraVer()
        {
            int sayac = 0;
            var numara = context.ogrencis.Select(m => new
            {
                m.Numara
            }).ToList();

            Random rndm = new Random();
            int a = rndm.Next(0, 100);

            while (sayac == 0)
            {
                sayac = 0;
                foreach (var item in numara)
                {

                    if (item.Numara == a)
                    {
                        a = rndm.Next(0, 100);
                        sayac = 0;
                        break;
                    }
                    else
                    {
                        sayac = 1;
                    }
                }
            }

            return a;
        }
        public IActionResult Silme()
        {
            var veri = context.ogrencis.Select(i => new OgrencıModel()
            {
                Id = i.Id,
                Ad = i.Ad,
                Soyad = i.Soyad,
                Numara = i.Numara,
                BolumAd = i.Bolum.BolumAd
            }).ToList();
            return View(veri);
        }
        public IActionResult Sil(int id)
        {
            var veri = context.ogrencis.Find(id);
            context.Remove(veri);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Güncelleme()
        {
            var veri = context.ogrencis.Select(i => new OgrencıModel()
            {
                Id = i.Id,
                Ad = i.Ad,
                Soyad = i.Soyad,
                Numara = i.Numara,
                BolumAd = i.Bolum.BolumAd
            }).ToList();
            return View(veri);
        }
        public IActionResult Güncelle(int id)
        {
            var veri = context.ogrencis.Find(id);
            List<SelectListItem> degerler = (from i in context.bolums.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.BolumAd,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View(veri);
        }
        [HttpPost]
        public IActionResult Güncelle(Ogrenci datas)
        {
            //degistirilecekler == ad soyad bolum
            var eski = context.ogrencis.Find(datas.Id);
            eski.Ad = datas.Ad;
            eski.Soyad = datas.Soyad;
            eski.BolumId = datas.Bolum.Id;
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
