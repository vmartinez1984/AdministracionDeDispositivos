using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class TipoDeDispositivoDao
    {
        public static List<TipoDeDispositivoEntity> GetAll()
        {
            try
            {
                List<TipoDeDispositivoEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM tipo_de_dispositivo
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<TipoDeDispositivoEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(TipoDeDispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO tipo_de_dispositivo 
                (
                    nombre
                ) 
                VALUES 
                (
                    @Nombre
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

        public static TipoDeDispositivoEntity Get(int id)
        {
            try
            {
                TipoDeDispositivoEntity entity;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM tipo_de_dispositivo
                WHERE id = {id}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<TipoDeDispositivoEntity>(query).FirstOrDefault();
                }

                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(TipoDeDispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"UPDATE tipo_de_dispositivo SET nombre = @Nombre WHERE id = @Id";
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
    }
}
