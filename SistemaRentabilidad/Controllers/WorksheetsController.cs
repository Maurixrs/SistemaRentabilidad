using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SistemaRentabilidad.Context;
using SistemaRentabilidad.Models;
using SistemaRentabilidad.Repositories;
using SistemaRentabilidad.ViewModels;

namespace SistemaRentabilidad.Controllers
{
    public class WorksheetsController : Controller
    {
        
        private WsRepository _repository = new WsRepository();
        private ContextSR db = new ContextSR();

        // GET: Worksheets
        public ActionResult Index()
        {
            IList<WsVM> WsVMList = new List<WsVM>();
            IList<Worksheet> WsList = _repository.FindAllE();
            WsVMList = Mapper.Map<IList<Worksheet>, IList<WsVM>>(WsList);
            return View(WsVMList);
        }

        // GET: Worksheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WsVM wsVm = new WsVM();
            Worksheet worksheet = _repository.FindE(id);
            wsVm = Mapper.Map<Worksheet, WsVM>(worksheet);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(wsVm);
        }

        public ActionResult CreateWorksheet()
        {
            var nsheet = 0;
            if (db.Worksheet != null & db.Worksheet.Count() != 0)
            {
                nsheet = db.Worksheet.ToList().LastOrDefault().IdWorksheet;
            }

            ViewBag.nsheet = nsheet + 1;

            return View();
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
        public ActionResult Create([Bind(Include = "IdWorksheet,Date,WorksheetDescription,TotalAmount,Comments")] WsVM wsVm)
        {
            if (ModelState.IsValid)
            {
                Worksheet worksheet = Mapper.Map<WsVM, Worksheet>(wsVm);
                _repository.AddE(worksheet);
                return RedirectToAction("Index");
            }

            return View(wsVm);
        }

        // GET: Worksheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = _repository.FindE(id);
            WsVM wsVm = Mapper.Map<Worksheet, WsVM>(worksheet);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(wsVm);
        }

        // POST: Worksheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdWorksheet,Date,WorksheetDescription,TotalAmount,Comments")] WsVM wsVm)
        {
            if (ModelState.IsValid)
            {
                Worksheet worksheet = Mapper.Map<WsVM, Worksheet>(wsVm);
                _repository.EditE(worksheet);
                return RedirectToAction("Index");
            }
            return View(wsVm);
        }

        // GET: Worksheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = _repository.FindE(id);
            WsVM wsVm = Mapper.Map<Worksheet, WsVM>(worksheet);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(wsVm);
        }

        // POST: Worksheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteE(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }
    }
}
