using Administracion.DataAccessObject.DataAccesObject;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.Entities
{
    public class TotalDeDispositivosDao
    {
        public static List<TotalDeDispositivosEntity> GetAll()
        {
            try
            {
                List<TotalDeDispositivosEntity> entities;
                string query;

                query = $@"
                SELECT 
	                tipo_de_dispositivo.nombre,
	                COUNT(tipo_de_dispositivo.id) Total
                FROM dispositivo
                INNER JOIN tipo_de_dispositivo ON dispositivo.tipo_de_dispositivo_id = tipo_de_dispositivo.id
                GROUP BY tipo_de_dispositivo.id
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<TotalDeDispositivosEntity>(query).ToList();
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