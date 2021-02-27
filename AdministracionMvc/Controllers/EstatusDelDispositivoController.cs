using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class EstatusDelDispositivoController : Controller
    {
        // GET: EstatusDelDispositivo
        public ActionResult Index()
        {
            List<EstatusDelDispositivo> lista;

            lista = EstatusDelDispositivoBl.GetAll();

            return View(lista);
        }

        // GET: EstatusDelDispositivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusDelDispositivo/Create
        [HttpPost]
        public ActionResult Create(EstatusDelDispositivo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EstatusDelDispositivoBl.Add(item);
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

        // GET: EstatusDelDispositivo/Edit/5
        public ActionResult Edit(int id)
        {
            EstatusDelDispositivo item;

            item = EstatusDelDispositivoBl.Get(id);

            return View(item);
        }

        // POST: EstatusDelDispositivo/Edit/5
        [HttpPost]
        public ActionResult Edit(EstatusDelDispositivo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EstatusDelDispositivoBl.Update(item);
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

        // GET: EstatusDelDispositivo/Delete/5
        public ActionResult Delete(int id)
        {
            EstatusDelDispositivo item;

            item = EstatusDelDispositivoBl.Get(id);

            return View(item);
        }

        // POST: EstatusDelDispositivo/Delete/5
        [HttpPost]
        public ActionResult Delete(EstatusDelDispositivo item)
        {
            try
            {
                EstatusDelDispositivoBl.Delete(item.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
