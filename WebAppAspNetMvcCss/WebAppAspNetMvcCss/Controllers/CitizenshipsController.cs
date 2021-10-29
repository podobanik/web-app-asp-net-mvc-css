using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcCss.Models;

namespace WebAppAspNetMvcCss.Controllers
{
    public class CitizenshipsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new GosuslugiContext();
            var citizenships = db.Citizenships.ToList();

            return View(citizenships);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var citizenships = new Citizenship();
            return View(citizenships);
        }

        [HttpPost]
        public ActionResult Create(Citizenship model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new GosuslugiContext();

            db.Citizenships.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Citizenships/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new GosuslugiContext();
            var citizenships = db.Citizenships.FirstOrDefault(x => x.Id == id);
            if (citizenships == null)
                return RedirectPermanent("/Citizenships/Index");

            db.Citizenships.Remove(citizenships);
            db.SaveChanges();

            return RedirectPermanent("/Citizenships/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new GosuslugiContext();
            var citizenships = db.Citizenships.FirstOrDefault(x => x.Id == id);
            if (citizenships == null)
                return RedirectPermanent("/Citizenships/Index");

            return View(citizenships);
        }

        [HttpPost]
        public ActionResult Edit(Citizenship model)
        {
            var db = new GosuslugiContext();
            var citizenships = db.Citizenships.FirstOrDefault(x => x.Id == model.Id);
            if (citizenships == null)
                ModelState.AddModelError("Id", "Гражданство не найдено");

            if (!ModelState.IsValid)
                return View(model);

            MappingCitizenships(model, citizenships);

            db.Entry(citizenships).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Citizenships/Index");
        }

        private void MappingCitizenships(Citizenship sourse, Citizenship destination)
        {
            destination.Name = sourse.Name;
            
        }
    }
}