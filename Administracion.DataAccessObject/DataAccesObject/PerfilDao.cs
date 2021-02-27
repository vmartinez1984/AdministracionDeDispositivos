using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class PerfilDao
    {
        public static List<PerfilEntity> GetAll()
        {
            try
            {
                List<PerfilEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM perfil
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<PerfilEntity>(query).ToList();
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
