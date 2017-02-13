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
    [Authorize(Users = "urdirom-dist@hotmail.com")]
    public class SheetsController : Controller
    {
        private ContextSR db = new ContextSR();

        // GET: Sheets
        public ActionResult Index()
        {
            var sheet = db.Sheet.Include(s => s.WorkSheet);
            return View(sheet.ToList());
        }

       

        // GET: Sheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sheet sheet = db.Sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            return View(sheet);
        }

        // GET: Sheets/Create
        public ActionResult Create(int? idws)
        {
            ViewBag.idws = idws;
            ViewBag.IdWorkSheet = new SelectList(db.Worksheet, "IdWorksheet", "Date");
            return View();
        }
     

        // POST: Sheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSheet,SheetDescription,Date,Amount,Iva,Comments,IdWorkSheet,SheetType")] Sheet sheet)
        {
            if (ModelState.IsValid)
            {
                db.Sheet.Add(sheet);
                db.SaveChanges();
                return RedirectToAction("Details", "Worksheets", new { id = sheet.IdWorkSheet });
            }

            ViewBag.IdWorkSheet = new SelectList(db.Worksheet, "IdWorksheet", "Date", sheet.IdWorkSheet);
            return View(sheet);
        }

        // GET: Sheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sheet sheet = db.Sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdWorkSheet = new SelectList(db.Worksheet, "IdWorksheet", "Date", sheet.IdWorkSheet);
            return View(sheet);
        }

        // POST: Sheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSheet,SheetDescription,Date,Amount,Iva,Comments,IdWorkSheet,SheetType")] Sheet sheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdWorkSheet = new SelectList(db.Worksheet, "IdWorksheet", "Date", sheet.IdWorkSheet);
            return View(sheet);
        }

        // GET: Sheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sheet sheet = db.Sheet.Find(id);
            if (sheet == null)
            {
                return HttpNotFound();
            }
            return View(sheet);
        }

        // POST: Sheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sheet sheet = db.Sheet.Find(id);
            db.Sheet.Remove(sheet);
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
