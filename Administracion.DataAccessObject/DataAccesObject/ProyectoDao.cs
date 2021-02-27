using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class ProyectoDao
    {
        public static List<ProyectoEntity> GetAll()
        {
            try
            {
                List<ProyectoEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Base},
                    {Campos.FechaDeBaja}
                FROM proyecto
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<ProyectoEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(ProyectoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO proyecto 
                (
                    nombre,
                    fecha_de_registro,
                    is_activo
                ) 
                VALUES 
                (
                    @Nombre,
                    NOW(),
                    1
                ); SELECT LAST_INSERT_ID();";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new { Nombre = entity.Nombre }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(ProyectoEntity entity)
        {
            try
            {
                string query;

                query = $@"UPDATE proyecto SET nombre = @Nombre WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query<int>(query, new { Nombre = entity.Nombre, Id = entity.Id });
                }

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
                string query;

                query = $@"UPDATE proyecto 
                SET 
                    is_activo = 0,
                    fecha_de_baja = NOW();    
                WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query<int>(query, new { Id = id });
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
