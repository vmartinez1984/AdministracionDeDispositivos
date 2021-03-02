using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Data;

namespace Administracion.BusinessLayer.Bl
{
    public class AgenciaYDispositivosBl
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

        public static void GetExcel(int proyectoId, string rutaDelExcel)
        {
            try
            {
                DataTable dataTable;
                List<AgenciaYDispositivoEntity> entities;
                SLDocument sLDocument;

                entities = AgenciaYDsipositivoDao.GetAll(proyectoId);
                dataTable = new DataTable();
                dataTable.Columns.Add("Clave", typeof(string));
                dataTable.Columns.Add("Nombre", typeof(string));
                dataTable.Columns.Add("Tipo", typeof(string));
                dataTable.Columns.Add("Ciudad", typeof(string));
                dataTable.Columns.Add("AT9000", typeof(string));
                dataTable.Columns.Add("CSD200/CSD300", typeof(string));
                dataTable.Columns.Add("Logitech CS252", typeof(string));
                dataTable.Columns.Add("PentaDesko", typeof(string));
                dataTable.Columns.Add("Kojak", typeof(string));
                foreach (var entity in entities)
                {
                    dataTable.Rows.Add(entity.AgenciaClave, entity.AgenciaNombre, entity.AgenciaTipo, entity.Ciudad, entity.Dispositivo1, entity.Dispositivo2, entity.Dispositivo3, entity.Dispositivo4, entity.Dispositivo5);
                }
                sLDocument = new SLDocument();
                sLDocument.ImportDataTable(1, 1, dataTable, true);
                sLDocument.SaveAs(rutaDelExcel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
