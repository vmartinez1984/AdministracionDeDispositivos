﻿using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
               return RedirectToAction("Login", "Home");

            ViewBag.ListaDeTotalDeDispositivos = TotalDeDispositivosBl.GetAll();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Buttons() { return View(); }
        public ActionResult Cards() { return View(); }
        public ActionResult Color() { return View(); }
        public ActionResult Borders() { return View(); }
        public ActionResult Animations() { return View(); }
        public ActionResult Other() { return View(); }
        public ActionResult Login()
        {
            Session["Usuario"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            Usuario usuario;
            string usuario_;
            string contrasenia;

            usuario_ = formCollection["Usuario"];
            contrasenia = formCollection["Contrasenia"];
            usuario = UsuarioBl.Get(usuario_, contrasenia);
            if (usuario == null)
            {
                ViewBag.Error = "Usuario y/o contraseña incorrecto(s)";
                return View();
            }
            else
            {
                Session["Usuario"] = usuario;
                Session["ListaDeProyectos"] = ProyectoBl.GetAll();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Register() { return View(); }
        public ActionResult ForgotPassword() { return View(); }
        public ActionResult Page404() { return View(); }
        public ActionResult PageBlank() { return View(); }
        public ActionResult Charts() { return View(); }
        public ActionResult Tables() { return View(); }
    }
}