using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class TipoDeDispositivoController : Controller
    {
        // GET: TipoDeDispositivo
        public ActionResult Index()
        {
            List<TipoDeDispositivo> lista;

            lista = TipoDeDispositivoBl.GetAll();

            return View(lista);
        }

        // GET: TipoDeDispositivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeDispositivo/Create
        [HttpPost]
        public ActionResult Create(TipoDeDispositivo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TipoDeDispositivoBl.Add(item);
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

        // GET: TipoDeDispositivo/Edit/5
        public ActionResult Edit(int id)
        {
            TipoDeDispositivo item;

            item = TipoDeDispositivoBl.Get(id);

            return View(item);
        }

        // POST: TipoDeDispositivo/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoDeDispositivo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TipoDeDispositivoBl.Update(item);
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
    }
}
