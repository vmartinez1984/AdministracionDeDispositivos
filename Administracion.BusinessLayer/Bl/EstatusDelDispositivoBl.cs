using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
   public class EstatusDelDispositivoBl
    {
        public static List<EstatusDelDispositivo> GetAll()
        {
            try
            {
                List<EstatusDelDispositivo> lista;
                List<EstatusDelDispositivoEntity> entities;

                entities = EstatusDeDispositivoDao.GetAll();
                lista = EstatusDelDsipositivoMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Add(EstatusDelDispositivo item)
        {
            try
            {
                EstatusDelDispositivoEntity entity;

                entity = EstatusDelDsipositivoMapper.Get(item);

                item.Id = EstatusDeDispositivoDao.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(EstatusDelDispositivo item)
        {
            try
            {
                EstatusDelDispositivoEntity entity;

                entity = EstatusDelDsipositivoMapper.Get(item);

                EstatusDeDispositivoDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static EstatusDelDispositivo Get(int id)
        {
            try
            {
                EstatusDelDispositivo item;
                EstatusDelDispositivoEntity entity;

                entity = EstatusDeDispositivoDao.Get(id);
                item = EstatusDelDsipositivoMapper.Get(entity);

                return item;
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
                EstatusDeDispositivoDao.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}