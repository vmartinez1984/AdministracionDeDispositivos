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
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<TipoDeDispositivo> lista;

            lista = TipoDeDispositivoBl.GetAll();

            return View(lista);
        }

        // GET: TipoDeDispositivo/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        // POST: TipoDeDispositivo/Create
        [HttpPost]
        public ActionResult Create(TipoDeDispositivo item)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

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
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

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
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

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
