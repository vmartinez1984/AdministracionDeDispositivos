using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using Administracion.BusinessLayer.Mapper;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public class TipoDeAgenciaBl
    {
        public static List<TipoDeAgencia> GetAll()
        {
            try
            {
                List<TipoDeAgencia> lista;

                lista = GetLista();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<TipoDeAgencia> GetLista()
        {
            List<TipoDeAgencia> lista;
            List<TipoDeAgenciaEntity> entities;

            entities = TipoDeAgenciaDao.GetAll();
            lista = TipoDeAgenciaMappers.GetAll(entities);

            return lista;
        }

        public static int Add(TipoDeAgencia item)
        {
            try
            {
                TipoDeAgenciaEntity entity;

                entity = TipoDeAgenciaMappers.Get(item);
                item.Id = TipoDeAgenciaDao.Add(entity);

                return item.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static TipoDeAgencia Get(int id)
        {
            try
            {
                TipoDeAgencia item;
                TipoDeAgenciaEntity entity;

                entity = TipoDeAgenciaDao.Get(id);
                item = TipoDeAgenciaMappers.Get(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(TipoDeAgencia item)
        {
            try
            {
                TipoDeAgenciaEntity entity;

                entity = TipoDeAgenciaMappers.Get(item);

                TipoDeAgenciaDao.Update(entity);
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

            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}