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
    [Authorize(Users = "urdirom-dist@hotmail.com")]
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
        public ActionResult Edit([Bind(Include = "IdSheetLine,LineDescription,SheetType")] SheetLine sheetLine)
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

        public JsonResult ExisteSugEdit(string sd, string st, int si)
        {

            var existe = db.SheetLines.ToList().Exists(f => f.LineDescription == sd & f.SheetType.ToString() == st & f.IdSheetLine != si);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }

    }
}
