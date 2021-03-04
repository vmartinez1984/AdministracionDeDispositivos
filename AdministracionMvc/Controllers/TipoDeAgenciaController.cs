using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class TipoDeAgenciaController : Controller
    {
        // GET: TipoDeAgencia
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<TipoDeAgencia> lista;

            lista = TipoDeAgenciaBl.GetAll();

            return View(lista);
        }

        // GET: TipoDeAgencia/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        // POST: TipoDeAgencia/Create
        [HttpPost]
        public ActionResult Create(TipoDeAgencia tipoDeAgencia)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                if (ModelState.IsValid)
                {
                    TipoDeAgenciaBl.Add(tipoDeAgencia);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: TipoDeAgencia/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                if (id == null)
                    return RedirectToAction("Index");
                else
                {
                    TipoDeAgencia item;

                    item = TipoDeAgenciaBl.Get((int)id);

                    return View(item);
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }

        // POST: TipoDeAgencia/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoDeAgencia item)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                TipoDeAgenciaBl.Update(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeAgencia/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                if (id == null)
                    return RedirectToAction("Index");
                else
                {
                    TipoDeAgencia item;

                    item = TipoDeAgenciaBl.Get((int)id);

                    return View(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TipoDeAgencia/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoDeAgencia item)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                TipoDeAgenciaBl.Delete(item.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
