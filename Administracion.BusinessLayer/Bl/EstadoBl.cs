using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public class EstadoBl
    {
        public static List<Estado> GetAll()
        {
            try
            {
                List<Estado> lista;

                lista = GetLista();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<Estado> GetLista()
        {
            List<Estado> lista;
            List<EstadoEntity> entities;

            entities = EstadoDao.GetAll();
            lista = EstadoMapper.GetAll(entities);

            return lista;
        }
    }
}