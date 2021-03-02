using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Bl
{
    public    class AgenciaYDispositivosBl
    {
        public static List<AgenciaYDispositivos> GetAll(int proyectoId)
        {
            try
            {
                List<AgenciaYDispositivos> lista;
                List<AgenciaYDispositivoEntity> entities;

                entities = AgenciaYDsipositivoDao.GetAll(proyectoId);
                lista = AgenciaYDispositivosMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
