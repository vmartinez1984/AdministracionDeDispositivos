using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<Proyecto> lista;

            lista = ProyectoBl.GetAll();

            return View(lista);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(Proyecto proyecto)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                if (ModelState.IsValid)
                {
                    ProyectoBl.Add(proyecto);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            if (id == null)
                return RedirectToAction("index");

            Proyecto proyecto;

            proyecto = ProyectoBl.GetAll().Where(x=> x.Id == id).FirstOrDefault();
            
            return View(proyecto);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(Proyecto proyecto)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                ProyectoBl.Update(proyecto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}