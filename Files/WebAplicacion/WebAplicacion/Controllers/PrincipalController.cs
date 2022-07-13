using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        // GET: Access
        public ActionResult Login()
        {
            return View();
        }


        // GET: Access/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Access/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Access/Create
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

        // GET: Access/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Access/Edit/5
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

        // GET: Access/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Access/Delete/5
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
