using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcHtml.Models;

namespace WebAppAspNetMvcHtml.Controllers
{
    public class AvailableDocumentsController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            var db = new GosuslugiContext();
            var availableDocuments = db.AvailableDocuments.ToList();

            return View(availableDocuments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var availableDocuments = new AvailableDocument();
            return View(availableDocuments);
        }

        [HttpPost]
        public ActionResult Create(AvailableDocument model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new GosuslugiContext();

            db.AvailableDocuments.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/AvailableDocuments/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new GosuslugiContext();
            var availableDocuments = db.AvailableDocuments.FirstOrDefault(x => x.Id == id);
            if (availableDocuments == null)
                return RedirectPermanent("/AvailableDocuments/Index");

            db.AvailableDocuments.Remove(availableDocuments);
            db.SaveChanges();

            return RedirectPermanent("/AvailableDocuments/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new GosuslugiContext();
            var availableDocuments = db.AvailableDocuments.FirstOrDefault(x => x.Id == id);
            if (availableDocuments == null)
                return RedirectPermanent("/AvailableDocuments/Index");

            return View(availableDocuments);
        }

        [HttpPost]
        public ActionResult Edit(AvailableDocument model)
        {
            var db = new GosuslugiContext();
            var availableDocuments = db.AvailableDocuments.FirstOrDefault(x => x.Id == model.Id);
            if (availableDocuments == null)
                ModelState.AddModelError("Id", "Документ не найден");

            if (!ModelState.IsValid)
                return View(model);

            MappingCitizenships(model, availableDocuments);

            db.Entry(availableDocuments).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/AvailableDocuments/Index");
        }

        private void MappingCitizenships(AvailableDocument sourse, AvailableDocument destination)
        {
            destination.Name = sourse.Name;
            
        }
    }
}