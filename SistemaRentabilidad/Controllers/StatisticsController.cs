using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using SistemaRentabilidad.Models;
using SistemaRentabilidad.Repositories;
using SistemaRentabilidad.ViewModels;

namespace SistemaRentabilidad.Controllers
{
    public class StatisticsController : Controller
    {
        private WsRepository _repository = new WsRepository();
        // GET: Statistics
        public ActionResult Incomes()
        {
            return View();
        }

        public ActionResult _Incomes(DateTime fecha1, DateTime fecha2)
        {
           
           
            IList<Worksheet> WsList = _repository.FindAllE();

            var FilteredList = from t in WsList
                where (t.Date >= fecha1 & t.Date <= fecha2)
                select t;
            List<decimal> incomes = FilteredList.Select(item => item.Totali).ToList();

            List<int> months = new List<int>();
            List<int> years = new List<int>();

            DateTime initDate = fecha1;

            while (initDate < fecha2)
            {
                months.Add(fecha1.Month);
                years.Add(fecha1.Year);
                initDate = initDate.AddMonths(1);
            }

            ViewBag.initDate = fecha1;
            ViewBag.endDate = fecha2;
            ViewBag.incomes = JsonConvert.SerializeObject(incomes);
            ViewBag.months = JsonConvert.SerializeObject(months);
            ViewBag.years = JsonConvert.SerializeObject(years);

            return View(FilteredList);
        }

        //public ActionResult OIncomes()
        //{
        //    return View();
        //}

        //public ActionResult _OIncomes()
        //{
        //    return View();
        //}

        //public ActionResult TotIncomes()
        //{
        //    return View();
        //}

        //public ActionResult _TotIncomes()
        //{
        //    return View();
        //}

        //public ActionResult Expenses()
        //{
        //    return View();
        //}

        //public ActionResult _Expenses()
        //{
        //    return View();
        //}

        //public ActionResult Costs()
        //{
        //    return View();
        //}

        //public ActionResult _Costs()
        //{
        //    return View();
        //}

        //public ActionResult TotMonthly()
        //{
        //    return View();
        //}

        //public ActionResult _TotMonthly()
        //{
        //    return View();
        //}
    }
}