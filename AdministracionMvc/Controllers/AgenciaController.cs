using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: Agencia
        public ActionResult Index()
        {
            List<AgenciaItem> lista;

            lista = AgenciaBl.GetAll();

            return View(lista);
        }

        // GET: Agencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("index");

            AgenciaDetalle agencia;

            agencia = AgenciaBl.GetDetalle((int)id);

            return View(agencia);
        }

        // GET: Agencia/Create
        public ActionResult Create()
        {
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
            ViewBag.ListaDeEstados = EstadoBl.GetAll();
            ViewBag.ListaDeTiposDeAgencia = TipoDeAgenciaBl.GetAll();

            return View();
        }

        // POST: Agencia/Create
        [HttpPost]
        public ActionResult Create(Agencia item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AgenciaBl.Add(item);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
                    ViewBag.ListaDeEstados = EstadoBl.GetAll();
                    ViewBag.ListaDeTiposDeAgencia = TipoDeAgenciaBl.GetAll();
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Agencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Agencia item;

            item = AgenciaBl.Get((int)id);
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
            ViewBag.ListaDeEstados = EstadoBl.GetAll();
            ViewBag.ListaDeTiposDeAgencia = TipoDeAgenciaBl.GetAll();

            return View(item);
        }

        // POST: Agencia/Edit/5
        [HttpPost]
        public ActionResult Edit(Agencia item)
        {
            try
            {
                item.UsuarioId = 1;
                AgenciaBl.Update(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("index");

            AgenciaDetalle agencia;

            agencia = AgenciaBl.GetDetalle((int)id);

            return View(agencia);
        }

        // POST: Agencia/Delete/5
        [HttpPost]
        public ActionResult Delete(Agencia item)
        {
            try
            {
                AgenciaBl.Delete(item.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetAll(int proyectoId)
        {
            List<AgenciaItem> lista;

            lista = AgenciaBl.GetAll(proyectoId);

            return Json(lista,JsonRequestBehavior.AllowGet);
        }
    }
}
