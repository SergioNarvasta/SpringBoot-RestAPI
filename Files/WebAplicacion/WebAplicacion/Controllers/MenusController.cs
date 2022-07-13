using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class MenusController : Controller
    {
        //private WebAppEntities webAppEntities = new WebAppEntities();
        // GET: Menus
        public ActionResult Index()
        {
            //ViewBag.MenuLevel1 = this.webAppEntities.Menus_men.Where(menu=>menu.men_padmen ==null).ToList();
            return View();
        }

        // GET: Menus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Menus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Menus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
