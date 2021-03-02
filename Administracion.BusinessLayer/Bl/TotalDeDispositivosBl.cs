using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public  class TotalDeDispositivosBl
    {
        public static List<TotalDeDispositivos> GetAll()
        {
            try
            {
                List<TotalDeDispositivos> lista;
                List<TotalDeDispositivosEntity> entities;

                entities = TotalDeDispositivosDao.GetAll();
                lista = TotalDeDispositivosMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
