using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models;


namespace WebAplicacion.Controllers
{
    public class HomeController : Controller
    {
        //private WebAppEntities webAppEntities = new WebAppEntities();
        // GET: Menus
        public ActionResult Index()
        {
            ViewBag.MenuLevel1 = ""; // this.webAppEntities.Menus_men.Where(menu => menu.men_padmen == null).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}