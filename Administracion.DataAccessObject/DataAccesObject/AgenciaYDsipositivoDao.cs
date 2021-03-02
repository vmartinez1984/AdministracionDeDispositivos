using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class AgenciaYDsipositivoDao
    {
        public static List<AgenciaYDispositivoEntity> GetAll(int proyectoId)
        {
            try
            {
                List<AgenciaYDispositivoEntity> entities;
                string query;

                query = $@"SELECT 
	                agencia.clave 						AgenciaClave,
	                agencia.nombre						AgenciaNombre,
	                tipo_de_agencia.nombre			AgenciaTipo,
	                agencia.ciudad						Ciudad,
                    (SELECT dispositivo.numero_de_serie FROM dispositivo WHERE dispositivo.agencia_id = agencia.id AND tipo_de_dispositivo_id = 1) Dispositivo1,
                    (SELECT dispositivo.numero_de_serie FROM dispositivo WHERE dispositivo.agencia_id = agencia.id AND tipo_de_dispositivo_id = 2) Dispositivo2,
	                (SELECT dispositivo.numero_de_serie FROM dispositivo WHERE dispositivo.agencia_id = agencia.id AND tipo_de_dispositivo_id = 3) Dispositivo3,
	                (SELECT dispositivo.numero_de_serie FROM dispositivo WHERE dispositivo.agencia_id = agencia.id AND tipo_de_dispositivo_id = 4) Dispositivo4,
	                (SELECT dispositivo.numero_de_serie FROM dispositivo WHERE dispositivo.agencia_id = agencia.id AND tipo_de_dispositivo_id = 5) Dispositivo5
                FROM	agencia
                INNER JOIN	tipo_de_agencia ON agencia.tipo_de_agencia_id = tipo_de_agencia.id
                WHERE agencia.proyecto_id = {proyectoId}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<AgenciaYDispositivoEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
