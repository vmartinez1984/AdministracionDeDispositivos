using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public class UsuarioBl
    {
        public static List<UsuarioItem> GetAll()
        {
            try
            {
                List<UsuarioItem> lista;
                List<UsuarioEntity> entities;

                entities = UsuarioDao.GetAll();
                lista = UsuarioMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<UsuarioItem> GetAllEliminados()
        {
            try
            {
                List<UsuarioItem> lista;
                List<UsuarioEntity> entities;

                entities = UsuarioDao.GetAllEliminados();
                lista = UsuarioMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Usuario Get(int id)
        {
            Usuario item;
            UsuarioEntity entity;

            entity = UsuarioDao.Get(id);
            item = UsuarioMapper.Get(entity);

            return item;
        }

        public static Usuario Get(string usuario, string contrasenia)
        {
            try
            {
                Usuario usuario1;
                UsuarioEntity usuarioEntity;

                usuarioEntity = UsuarioDao.Get(usuario, contrasenia);
                usuario1 = UsuarioMapper.Get(usuarioEntity);

                return usuario1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Add(Usuario item)
        {
            try
            {
                UsuarioEntity entity;

                entity = UsuarioMapper.Get(item);

                UsuarioDao.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Usuario item)
        {
            try
            {
                UsuarioEntity entity;

                entity = UsuarioMapper.Get(item);

                UsuarioDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                UsuarioDao.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}