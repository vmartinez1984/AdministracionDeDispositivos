using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class DispositivoController : Controller
    {
        // GET: Dispositivo
        public ActionResult Index()
        {
            List<DispositivoItem> lista;

            lista = DispositivoBl.GetAll();

            return View(lista);
        }

        // GET: Dispositivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            DispositivoDetalle item;

            item = DispositivoBl.GetDetalle((int)id);

            return View(item);
        }

        // GET: Dispositivo/Create
        public ActionResult Create()
        {
            ViewBag.ListaDeEstatusDeDispositivo = EstatusDelDispositivoBl.GetAll();
            ViewBag.ListaDeTiposDeDispositivos = TipoDeDispositivoBl.GetAll();
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
            return View();
        }

        // POST: Dispositivo/Create
        [HttpPost]
        public ActionResult Create(Dispositivo item, List<HttpPostedFileBase> Archivos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.Id = DispositivoBl.Add(item);

                    AddFiles(item.Id, Archivos);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDeEstatusDeDispositivo = EstatusDelDispositivoBl.GetAll();
                    ViewBag.ListaDeTiposDeDispositivos = TipoDeDispositivoBl.GetAll();
                    ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        private void AddFiles(int dispositivoId, List<HttpPostedFileBase> ListaDeArchivos)
        {
            if (ListaDeArchivos != null)
                foreach (var archivo in ListaDeArchivos)
                {
                    string nombreDeArchivo;
                    string rutaDelArchivo;
                    string directorio;

                    nombreDeArchivo = Path.GetFileName(archivo.FileName);
                    directorio = Server.MapPath("~/UploadedFiles");
                    directorio = $"{directorio}\\{dispositivoId}";
                    if (!Directory.Exists(directorio))
                        Directory.CreateDirectory(directorio);
                    rutaDelArchivo = Path.Combine(directorio, nombreDeArchivo);
                    archivo.SaveAs(rutaDelArchivo);
                    ArchivoDeDispositivoBl.Add(rutaDelArchivo, dispositivoId);
                }
        }

        // GET: Dispositivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            Dispositivo item;

            item = DispositivoBl.Get((int)id);
            ViewBag.ListaDeEstatusDeDispositivo = EstatusDelDispositivoBl.GetAll();
            ViewBag.ListaDeTiposDeDispositivos = TipoDeDispositivoBl.GetAll();
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
            ViewBag.ListaDeAgencias = AgenciaBl.GetAllAgenciaItem(item.ProyectoId);

            return View(item);
        }

        // POST: Dispositivo/Edit/5
        [HttpPost]
        public ActionResult Edit(Dispositivo item, List<HttpPostedFileBase> Archivos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.UsuarioId = 1;
                    DispositivoBl.Update(item);

                    AddFiles(item.Id, Archivos);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDeEstatusDeDispositivo = EstatusDelDispositivoBl.GetAll();
                    ViewBag.ListaDeTiposDeDispositivos = TipoDeDispositivoBl.GetAll();
                    ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
                    ViewBag.ListaDeAgencias = AgenciaBl.GetAllAgenciaItem(item.ProyectoId);

                    return View(item);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Dispositivo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dispositivo/Delete/5
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

        public ActionResult CargarExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarExcel(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult Buscar()
        {
            ViewBag.ListaDeEstatusDeDispositivo = EstatusDelDispositivoBl.GetAll();
            ViewBag.ListaDeTiposDeDispositivos = TipoDeDispositivoBl.GetAll();
            ViewBag.ListaDeProyectos = ProyectoBl.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(DispositivoBusqueda item)
        {
            List<DispositivoItem> lista;

            lista = DispositivoBl.GetAll(item);

            return View("index", lista);
        }
    }
}
