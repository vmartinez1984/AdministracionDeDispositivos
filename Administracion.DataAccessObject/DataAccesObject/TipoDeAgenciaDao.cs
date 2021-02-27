using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class TipoDeAgenciaDao
    {
        public static List<TipoDeAgenciaEntity> GetAll()
        {
            try
            {
                List<TipoDeAgenciaEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM tipo_de_agencia
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<TipoDeAgenciaEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(TipoDeAgenciaEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO tipo_de_agencia (nombre) VALUES (@Nombre); SELECT LAST_INSERT_ID();";
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

        public static void Update(TipoDeAgenciaEntity entity)
        {
            try
            {
                string query;

                query = $@"UPDATE tipo_de_agencia SET nombre = @Nombre WHERE id = @Id";
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

        public static TipoDeAgenciaEntity Get(int id)
        {
            try
            {
                TipoDeAgenciaEntity entity;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM tipo_de_agencia
                WHERE id = {id}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<TipoDeAgenciaEntity>(query).FirstOrDefault();
                }

                return entity;

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

                query = $@"UPDATE tipo_de_agencia SET is_activo = 0  WHERE id = @Id";
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
    }//end class
}