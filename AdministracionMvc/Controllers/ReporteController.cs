using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult ListaDeAgenciaYDispositivos(int ProyectoId)
        {
            List<AgenciaYDispositivos> lista;

            lista = AgenciaYDispositivosBl.GetAll(ProyectoId);
            ViewBag.ProyectoId = ProyectoId;

            return View(lista);
        }

        public ActionResult Excel(int id)
        {
            string rutaDelArchivo;
            string nombreDelArchivo;

            nombreDelArchivo = "Reporte.xlsx";
            rutaDelArchivo = Path.Combine(Server.MapPath("~/Temporal"), nombreDelArchivo);
            AgenciaYDispositivosBl.GetExcel(id, rutaDelArchivo);

            return File(rutaDelArchivo, "application/vnd.ms-excel", nombreDelArchivo);
        }
    }
}