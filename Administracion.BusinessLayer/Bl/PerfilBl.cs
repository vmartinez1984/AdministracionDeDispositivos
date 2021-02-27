using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public class PerfilBl
    {
        public static List<Perfil> GetAll()
        {
            try
            {
                List<Perfil> lista;
                List<PerfilEntity> entities;

                entities = PerfilDao.GetAll();
                lista = PerfilMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}