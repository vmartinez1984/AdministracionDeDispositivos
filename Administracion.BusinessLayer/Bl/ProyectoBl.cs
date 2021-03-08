using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.BusinessLayer.Bl
{
    public class ProyectoBl
    {
        public static List<Proyecto> GetAll()
        {
            try
            {
                List<Proyecto> lista;

                lista = GetListaDeProyectos();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<Proyecto> GetListaDeProyectos()
        {
            List<Proyecto> lista;
            List<ProyectoEntity> entities;

            entities = ProyectoDao.GetAll();
            lista = ProyectoMapper.GetAll(entities);

            return lista;
        }

        public static int Add(Proyecto proyecto)
        {
            try
            {
                ProyectoEntity entity;

                entity = ProyectoMapper.Get(proyecto);
                entity.Id = ProyectoDao.Add(entity);

                return proyecto.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Proyecto Get(int id)
        {
            List<Proyecto> lista;
            Proyecto proyecto;

            lista = GetListaDeProyectos();
            proyecto = lista.Where(x => x.Id == id).FirstOrDefault();

            return proyecto;
        }

        public static void Update(Proyecto proyecto)
        {
            try
            {
                ProyectoEntity entity;

                entity = ProyectoMapper.Get(proyecto);

                ProyectoDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}