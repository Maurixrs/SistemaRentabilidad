using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaRentabilidad.Context;
using SistemaRentabilidad.Models;

namespace SistemaRentabilidad.Controllers
{
    public class WorksheetsController : Controller
    {
        private ContextSR db = new ContextSR();

        // GET: Worksheets
        public ActionResult Index()
        {
            return View(db.Worksheet.ToList());
        }

        // GET: Worksheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // GET: Worksheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worksheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdWorksheet,Date,WorksheetDescription,TotalAmount,Comments")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Worksheet.Add(worksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worksheet);
        }

        // GET: Worksheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // POST: Worksheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdWorksheet,Date,WorksheetDescription,TotalAmount,Comments")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worksheet);
        }

        // GET: Worksheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // POST: Worksheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worksheet worksheet = db.Worksheet.Find(id);
            db.Worksheet.Remove(worksheet);
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
