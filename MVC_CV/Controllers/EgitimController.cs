﻿using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitim> repo = new GenericRepository<TblEgitim>();

        public ActionResult Index()
        {
            var egitim = repo.List(); ;
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=> x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik = t.AltBaslik;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.GNO = t.GNO;
            egitim.Tarih = t.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
        

    }
}