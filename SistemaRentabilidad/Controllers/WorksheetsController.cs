using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using SistemaRentabilidad.Context;
using SistemaRentabilidad.Models;
using SistemaRentabilidad.Repositories;
using SistemaRentabilidad.ViewModels;

namespace SistemaRentabilidad.Controllers
{
    [Authorize(Users = "urdirom-dist@hotmail.com")]
    public class WorksheetsController : Controller
    {

        private WsRepository _repository = new WsRepository();
        private ContextSR db = new ContextSR();

        // GET: Worksheets
        public ActionResult Index(int? x)
        {
            if (x != null) { TempData["mimsg"] = x; return RedirectToAction("Index");
            }

            IList<WsVM> WsVMList = new List<WsVM>();
            IList<Worksheet> WsList = _repository.FindAllE();
            WsVMList = Mapper.Map<IList<Worksheet>, IList<WsVM>>(WsList);
            return View(WsVMList);
        }

        public ActionResult HelpIndex()
        {
            return View();
        }

        public ActionResult FindW(DateTime fdate)
        {
            var id = db.Worksheet.ToList().Find(f => f.Date.Year == fdate.Year & f.Date.Month == fdate.Month).IdWorksheet;

            return RedirectToAction("Details", new { id = id });
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
        public ActionResult DetailsLast()
        {
            var id = db.Worksheet.ToList().LastOrDefault().IdWorksheet;
            TempData["mimsg"] = 1;
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult EditW(int? id)
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

            List<string> lines = new List<string>();
            List<string> linesi = new List<string>();
            List<string> linesc = new List<string>();
            List<string> linesg = new List<string>();
            List<string> lineso = new List<string>();

            foreach (var x in db.SheetLines)
            {
                if (x.SheetType == SheetType.Ingreso)
                { linesi.Add(x.LineDescription); }
                else
                {
                    if (x.SheetType == SheetType.Costo)
                    { linesc.Add(x.LineDescription); }
                    else
                    {
                        if (x.SheetType == SheetType.Gasto)
                        { linesg.Add(x.LineDescription); }
                        else
                        {
                            if (x.SheetType == SheetType.OtroIngreso)
                            { lineso.Add(x.LineDescription); }
                        }
                    }

                }

                lines.Add(x.LineDescription);
            }

            ViewBag.lines = JsonConvert.SerializeObject(lines);
            ViewBag.linesi = JsonConvert.SerializeObject(linesi);
            ViewBag.linesc = JsonConvert.SerializeObject(linesc);
            ViewBag.linesg = JsonConvert.SerializeObject(linesg);
            ViewBag.lineso = JsonConvert.SerializeObject(lineso);

            return View(wsVm);
        }

        [HttpPost]
        public JsonResult EditW(WsVM O)
        {
            //CustomerName contiene el id del cliente
            bool status = false;

            Worksheet wx = db.Worksheet.Find(O.IdWorksheet);
            var existe = db.Worksheet.ToList().Exists(f => f.Date.Year == O.Date.Year & f.Date.Month == O.Date.Month & f.IdWorksheet != O.IdWorksheet);
            if (existe) { return new JsonResult { Data = new { status = status, mensaje = "Ya existe una planilla con ese periodo." } }; }

            List<int> sheetsid = new List<int>();
            foreach (var item in wx.Sheets.ToList())
            {
                sheetsid.Add(item.IdSheet);
            }
            foreach (var elim in sheetsid)
            {
                Sheet sheet = new Sheet();
                sheet = db.Sheet.Find(elim);
                db.Sheet.Remove(sheet);
                db.SaveChanges();

            }

            Worksheet ws = db.Worksheet.Find(O.IdWorksheet);
            if (ModelState.IsValid)
            {

                ws.Date = O.Date;
                ws.Comments = O.Comments;
                ws.TotalAmount = O.TotalAmount;
                ws.Totali = O.Totali;
                ws.Totalc = O.Totalc;
                ws.Totalg = O.Totalg;
                ws.Totalo = O.Totalo;
                db.Entry(ws).State = EntityState.Modified;
                db.SaveChanges();

                foreach (var i in O.Sheets)
                {
                    var exline = db.SheetLines.ToList().Exists(f => f.LineDescription == i.SheetDescription & f.SheetType == i.SheetType);

                    if (!exline)
                    {
                        var newline = new SheetLine();
                        newline.LineDescription = i.SheetDescription;
                        newline.SheetType = i.SheetType;
                        db.SheetLines.Add(newline);
                        db.SaveChanges();
                    }

                    Sheet sh = new Sheet();
                    sh.SheetDescription = i.SheetDescription;
                    sh.Amount = i.Amount;
                    sh.Comments = i.Comments;
                    sh.SheetType = i.SheetType;
                    sh.IdWorkSheet = ws.IdWorksheet;

                    db.Sheet.Add(sh);
                    db.SaveChanges();
                }
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status, num = ws.IdWorksheet } };
        }

        public ActionResult HelpCreate()
        {
            return View();
        }

        public ActionResult HelpEdit()
        {
            return View();
        }



        public ActionResult CreateWorksheet()
        {
            var nsheet = 0;
            if (db.Worksheet != null & db.Worksheet.Count() != 0)
            {
                nsheet = db.Worksheet.ToList().LastOrDefault().IdWorksheet;
            }
            List<string> lines = new List<string>();
            List<string> linesi = new List<string>();
            List<string> linesc = new List<string>();
            List<string> linesg = new List<string>();
            List<string> lineso = new List<string>();

            foreach (var x in db.SheetLines)
            {
                if (x.SheetType == SheetType.Ingreso)
                { linesi.Add(x.LineDescription); }
                else
                {
                    if (x.SheetType == SheetType.Costo)
                    { linesc.Add(x.LineDescription); }
                    else
                    {
                        if (x.SheetType == SheetType.Gasto)
                        { linesg.Add(x.LineDescription); }
                        else
                        {
                            if (x.SheetType == SheetType.OtroIngreso)
                            { lineso.Add(x.LineDescription); }
                        }
                    }

                }

                lines.Add(x.LineDescription);
            }

            ViewBag.nsheet = nsheet + 1;
            ViewBag.lines = JsonConvert.SerializeObject(lines);
            ViewBag.linesi = JsonConvert.SerializeObject(linesi);
            ViewBag.linesc = JsonConvert.SerializeObject(linesc);
            ViewBag.linesg = JsonConvert.SerializeObject(linesg);
            ViewBag.lineso = JsonConvert.SerializeObject(lineso);
            return View();
        }

        public ActionResult CreateWs()
        {
            var nsheet = 0;
            if (db.Worksheet != null & db.Worksheet.Count() != 0)
            {
                nsheet = db.Worksheet.ToList().LastOrDefault().IdWorksheet;
            }

            List<Sheet> sheets = new List<Sheet>();

            foreach (var i in db.Transactions)
            {
                Sheet sheet = new Sheet();
                sheet.SheetDescription = i.TransactionDescription;
                sheet.SheetType = i.SheetType;
                sheet.Amount = 0;
                sheet.Comments = String.Empty;
                
                sheets.Add(sheet);
            }

            List<string> lines = new List<string>();
            List<string> linesi = new List<string>();
            List<string> linesc = new List<string>();
            List<string> linesg = new List<string>();
            List<string> lineso = new List<string>();

            foreach (var x in db.SheetLines)
            {
                if (x.SheetType == SheetType.Ingreso)
                { linesi.Add(x.LineDescription); }
                else
                {
                    if (x.SheetType == SheetType.Costo)
                    { linesc.Add(x.LineDescription); }
                    else
                    {
                        if (x.SheetType == SheetType.Gasto)
                        { linesg.Add(x.LineDescription); }
                        else
                        {
                            if (x.SheetType == SheetType.OtroIngreso)
                            { lineso.Add(x.LineDescription); }
                        }
                    }

                }

                lines.Add(x.LineDescription);
            }

            ViewBag.nsheet = nsheet + 1;
            ViewBag.lines = JsonConvert.SerializeObject(lines);
            ViewBag.linesi = JsonConvert.SerializeObject(linesi);
            ViewBag.linesc = JsonConvert.SerializeObject(linesc);
            ViewBag.linesg = JsonConvert.SerializeObject(linesg);
            ViewBag.lineso = JsonConvert.SerializeObject(lineso);

            return View(sheets);
        }

        [HttpPost]
        public JsonResult CreateWorksheet(WsVM O)
        {
            //CustomerName contiene el id del cliente
            bool status = false;
            var existe = db.Worksheet.ToList().Exists(f => f.Date.Year == O.Date.Year & f.Date.Month == O.Date.Month);
            if (existe) { return new JsonResult { Data = new { status = status, mensaje = "Ya existe una planilla con ese periodo." } }; }

            Worksheet ws = new Worksheet();

            if (ModelState.IsValid)
            {

                ws.Date = O.Date;
                ws.Comments = O.Comments;
                ws.TotalAmount = O.TotalAmount;
                ws.Totali = O.Totali;
                ws.Totalc = O.Totalc;
                ws.Totalg = O.Totalg;
                ws.Totalo = O.Totalo;


                db.Worksheet.Add(ws);
                db.SaveChanges();

                foreach (var i in O.Sheets)
                {
                    var exline = db.SheetLines.ToList().Exists(f => f.LineDescription == i.SheetDescription & f.SheetType == i.SheetType);

                    if (!exline)
                    {
                        var newline = new SheetLine();
                        newline.LineDescription = i.SheetDescription;
                        newline.SheetType = i.SheetType;
                        db.SheetLines.Add(newline);
                        db.SaveChanges();
                    }



                    Sheet sh = new Sheet();
                    sh.SheetDescription = i.SheetDescription;
                    sh.Amount = i.Amount;
                    sh.Comments = i.Comments;
                    sh.SheetType = i.SheetType;
                    sh.IdWorkSheet = ws.IdWorksheet;

                    db.Sheet.Add(sh);
                    db.SaveChanges();
                }
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }



        public JsonResult GetLines()
        {

            List<string> lines = new List<string>();

            foreach (var x in db.SheetLines)
            {
                lines.Add(x.LineDescription);
            }

            return Json(lines, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExistePlanilla(DateTime fecha)
        {
            Console.Write(fecha);
            var existe = db.Worksheet.ToList().Exists(f => f.Date.Year == fecha.Year & f.Date.Month == fecha.Month);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExistePlanillaEdit(DateTime fecha, int idp)
        {

            var existe = db.Worksheet.ToList().Exists(f => f.Date.Year == fecha.Year & f.Date.Month == fecha.Month & f.IdWorksheet != idp);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }




        // GET: Worksheets/Delete/5
        public ActionResult Delete(int? id, bool details)
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

            if (details)
            {
                return View(wsVm);
            }
            else
            {
                return View("DeleteIndex", wsVm);
            }


        }

        // POST: Worksheets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repository.DeleteE(id);
            TempData["mimsg"] = 1;
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
