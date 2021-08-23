using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissingPersons.Models;

namespace MissingPersons.Controllers
{
    public class MissingPersonsController : Controller
    {
        private MissingPersonEntities db = new MissingPersonEntities();

        // GET: MissingPersons
        public ActionResult Index()
        {
            return View(db.MissingPerson.ToList());
        }

        // GET: MissingPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPerson.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // GET: MissingPersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissingPersons/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SecondName,Surname,DateOfBirth,EyeColor,Height,DistinguishingMarks,LastSeenDate,LastSeenPlace,Picture")] MissingPerson missingPerson)
        {
            if (ModelState.IsValid)
            {
                db.MissingPerson.Add(missingPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missingPerson);
        }

        // GET: MissingPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPerson.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // POST: MissingPersons/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SecondName,Surname,DateOfBirth,EyeColor,Height,DistinguishingMarks,LastSeenDate,LastSeenPlace,Picture")] MissingPerson missingPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missingPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missingPerson);
        }

        // GET: MissingPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissingPerson missingPerson = db.MissingPerson.Find(id);
            if (missingPerson == null)
            {
                return HttpNotFound();
            }
            return View(missingPerson);
        }

        // POST: MissingPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissingPerson missingPerson = db.MissingPerson.Find(id);
            db.MissingPerson.Remove(missingPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
