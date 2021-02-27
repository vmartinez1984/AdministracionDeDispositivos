using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public class TipoDeDispositivoBl
    {
        public static List<TipoDeDispositivo> GetAll()
        {
            try
            {
                List<TipoDeDispositivo> lista;

                lista = GetLista();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<TipoDeDispositivo> GetLista()
        {
            List<TipoDeDispositivo> lista;
            List<TipoDeDispositivoEntity> entities;

            entities = TipoDeDispositivoDao.GetAll();
            lista = TipoDeDispositivoMapper.GetAll(entities);

            return lista;
        }

        public static int Add(TipoDeDispositivo item)
        {
            try
            {
                TipoDeDispositivoEntity entity;

                entity = TipoDeDispositivoMapper.Get(item);
                entity.Id = TipoDeDispositivoDao.Add(entity);

                return item.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static TipoDeDispositivo Get(int id)
        {
            try
            {
                TipoDeDispositivo item;
                TipoDeDispositivoEntity entity;

                entity = TipoDeDispositivoDao.Get(id);
                item = TipoDeDispositivoMapper.Get(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(TipoDeDispositivo item)
        {
            TipoDeDispositivoEntity entity;

            entity = TipoDeDispositivoMapper.Get(item);

            TipoDeDispositivoDao.Update(entity);
        }

    }
}