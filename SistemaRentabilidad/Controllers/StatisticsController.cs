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
    [Authorize(Users = "urdirom-dist@hotmail.com")]
    public class StatisticsController : Controller
    {
        private WsRepository _repository = new WsRepository();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Graphic(int fecha1, int fecha2, string selectedStat)
        {
            IList<Worksheet> WsList = _repository.FindAllE();

            var ys = fecha2 - fecha1;
            var incomes = new List<decimal> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var q = 0;

            IList<Worksheet> oclist=new List<Worksheet>();
            for (int i = 0; i < ys; i++)
            {
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
                incomes.Add(0);
            }
            var typeStat = "";
            switch (selectedStat)
            {
                case "Ingresos":
                    
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;

                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.Totali;
                        }

                        q++;
                    }
                    typeStat = "Ingresos";
                    break;
                case "Gastos":
                    
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;
                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.Totalg;
                        }

                        q++;
                    }
                    typeStat = "Gastos";
                    break;
                case "Costos":
                    
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;
                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.Totalc;
                        }

                        q++;
                    }
                    typeStat = "Costos";
                    break;

                case "OtrosIng":
                    
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;
                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.Totalo;
                        }

                        q++;
                    }
                    typeStat = "Otros Ingresos";
                    break;

                case "TotIng":
                   
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;
                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.Totali + item.Totalo;
                        }

                        q++;
                    }

                    typeStat = "Total Ingresos";
                    break;

                case "TotMens":
                   
                    for (int i = fecha1; i <= fecha2; i++)
                    {

                        var FilteredList = from t in WsList
                                           where (t.Date.Year == i)
                                           select t;
                        foreach (var item in FilteredList)
                        {
                            incomes[(item.Date.Month - 1) + (12 * q)] = item.TotalAmount;
                        }

                        q++;
                    }
                    typeStat = "Total Mensual";

                    break;
                    
            }


            ViewBag.initDate = fecha1;
            ViewBag.typeStat = typeStat;
            ViewBag.endDate = fecha2;
            ViewBag.incomes = JsonConvert.SerializeObject(incomes);
            ViewBag.years = fecha1;
            ViewBag.ys = ys;
            return View(WsList);


        }
        
    }
}