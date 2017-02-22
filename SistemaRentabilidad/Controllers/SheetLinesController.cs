using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaRentabilidad.Context;
using SistemaRentabilidad.Models;

namespace SistemaRentabilidad.Controllers
{
    public class SheetLinesController : Controller
    {
        private ContextSR db = new ContextSR();

        // GET: SheetLines
        public ActionResult Index()
        {
            return View(db.SheetLines.ToList());
        }

        // GET: SheetLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheetLine sheetLine = db.SheetLines.Find(id);
            if (sheetLine == null)
            {
                return HttpNotFound();
            }
            return View(sheetLine);
        }

        // GET: SheetLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SheetLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSheetLine,LineDescription")] SheetLine sheetLine)
        {
            if (ModelState.IsValid)
            {
                db.SheetLines.Add(sheetLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sheetLine);
        }

        // GET: SheetLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheetLine sheetLine = db.SheetLines.Find(id);
            if (sheetLine == null)
            {
                return HttpNotFound();
            }
            return View(sheetLine);
        }

        // POST: SheetLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSheetLine,LineDescription")] SheetLine sheetLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sheetLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sheetLine);
        }

        // GET: SheetLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheetLine sheetLine = db.SheetLines.Find(id);
            if (sheetLine == null)
            {
                return HttpNotFound();
            }
            return View(sheetLine);
        }

        // POST: SheetLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SheetLine sheetLine = db.SheetLines.Find(id);
            db.SheetLines.Remove(sheetLine);
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

        public JsonResult ExisteSug(string sd, SheetLine st)
        {

            var existe = db.SheetLines.ToList().Exists(f => f.LineDescription == sd & f.SheetType == st.SheetType);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExisteSugEdit(SheetLine s)
        {

            var existe = db.SheetLines.ToList().Exists(f => f.LineDescription == s.LineDescription & f.SheetType == s.SheetType & f.IdSheetLine != s.IdSheetLine);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }

    }
}
