using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models.ViewModels;

namespace WebAplicacion.Controllers
{
    public class EstadisticasController : Controller
    {
        // GET: Estadisticas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(string objCorreo)
        {
            
            Correo correo = new Correo();
            //string resp = correo.EnviarCorreo(CorreoDestino, Asunto, Mensaje);
            //string resp2 = correo.EnviarCorreo2();
           string resp3 = correo.EnviarCorreo3();
            ViewBag.Mensaje = "Enviado....";
            return View();

        }

        // GET: Estadisticas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estadisticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadisticas/Create
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

        // GET: Estadisticas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estadisticas/Edit/5
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

        // GET: Estadisticas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estadisticas/Delete/5
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
