using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaRentabilidad.Context;

namespace SistemaRentabilidad.Controllers
{
    [Authorize(Users = "urdirom-dist@hotmail.com")]
    public class HomeController : Controller
    {
        private ContextSR db = new ContextSR();

        [AllowAnonymous]
        public ActionResult Index()
        {
            try
            {
                @ViewBag.lastws = db.Worksheet.ToList().LastOrDefault().IdWorksheet;
            }
            catch (Exception)
            {

                @ViewBag.lastws = 0;
            }
                
            
            return View();
        }

        public ActionResult HelpHome()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}