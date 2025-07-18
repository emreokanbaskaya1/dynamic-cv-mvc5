﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
namespace MVC_CV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=> x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)
        {
            var yetenek = repo.Find(x => x.ID == t.ID);
            yetenek.Yetenek= t.Yetenek;
            yetenek.Oran = t.Oran;
            repo.TUpdate(yetenek);
            return RedirectToAction("Index");
        }


    }
}