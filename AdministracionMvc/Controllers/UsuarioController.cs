﻿using Administracion.BusinessLayer.Bl;
using Administracion.BusinessLayer.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdministracionMvc.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            List<UsuarioItem> lista;

            lista = UsuarioBl.GetAll();

            return View(lista);
        }

        // GET: Usuario
        public ActionResult Eliminados()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<UsuarioItem> lista;

            lista = UsuarioBl.GetAllEliminados();

            return View(lista);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            if (id == null)
                return RedirectToAction("Index");

            Usuario item;

            item = UsuarioBl.Get((int)id);

            return View(item);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            ViewBag.ListaDePerfiles = PerfilBl.GetAll();

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                
                if (ModelState.IsValid)
                {
                    UsuarioBl.Add(usuario);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDePerfiles = PerfilBl.GetAll();

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            if (id == null)
                return RedirectToAction("Index");

            Usuario usuario;

            usuario = UsuarioBl.Get((int)id);
            ViewBag.ListaDePerfiles = PerfilBl.GetAll();

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                if (ModelState.IsValid)
                {
                    UsuarioBl.Update(usuario);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDePerfiles = PerfilBl.GetAll();

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            if (id == null)
             return   RedirectToAction("Index");
            Usuario usuario;

            usuario = UsuarioBl.Get((int)id);

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                UsuarioBl.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
