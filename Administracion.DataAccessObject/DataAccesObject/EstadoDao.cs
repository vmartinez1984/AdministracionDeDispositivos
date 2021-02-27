using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class EstadoDao
    {
        public static List<EstadoEntity> GetAll()
        {
            try
            {
                List<EstadoEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM estado
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<EstadoEntity>(query).ToList();
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
